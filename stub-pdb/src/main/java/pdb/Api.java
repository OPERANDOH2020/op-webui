package pdb;

import eu.operando.api.model.DtoPrivacyRegulation.PrivateInformationTypeEnum;
import eu.operando.api.model.DtoPrivacyRegulation.RequiredConsentEnum;
import io.swagger.annotations.ApiParam;
import eu.operando.api.model.PrivacyRegulation;
import eu.operando.api.model.PrivacyRegulationInput;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.Random;
import java.util.UUID;
import java.util.Vector;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.atomic.AtomicInteger;
import java.util.concurrent.locks.Lock;

import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.HeaderParam;
import javax.ws.rs.POST;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import javax.ws.rs.core.Response.Status;

import com.google.gson.FieldNamingPolicy;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

@Path("/api")
public class Api
{
  static Random random = new Random();
  static int random_max_int = 9999999;

  static ConcurrentHashMap<String, PrivacyRegulation> regulations;
  static ConcurrentHashMap<String, PrivacyPolicy> policies;
  
  static{
    regulations = new ConcurrentHashMap<>();
    policies = new ConcurrentHashMap<>();
    int toAdd = 5;
    for(int i = 0; i < toAdd; i++){
      addRandomRegulation();
      addRandomPolicy(toAdd);
    }
    policies.put("ami", new PrivacyPolicy("ami", new ArrayList<AccessPolicy>()));
    policies.get("ami").policies.add(new AccessPolicy("user", "subjectType", "dataType", "reason"));
    policies.get("ami").policies.add(new AccessPolicy("user2", "subjectType2", "dataType2", "reason2"));
  };
  
  static void addRandomRegulation(){
    String id = UUID.randomUUID().toString();
    PrivacyRegulation reg = new PrivacyRegulation(
        id, 
        Integer.toString(random.nextInt(random_max_int)), 
        Integer.toString(random.nextInt(random_max_int)), 
        PrivateInformationTypeEnum.values()[random.nextInt(PrivateInformationTypeEnum.values().length)],
        Integer.toString(random.nextInt(random_max_int)), 
        RequiredConsentEnum.values()[random.nextInt(RequiredConsentEnum.values().length)]
     );
    regulations.put(id, reg);  
  }
  
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	@Path("/regulations")
	public Response getRegulations()
	{	
		return Response.ok().entity(createStringJsonFollowingOperandoConventions(regulations.values())).build();
	}

  @GET
  @Produces(MediaType.APPLICATION_JSON)
  @Path("/regulations/{reg-id}")
  public Response getRegulations(@PathParam("reg-id") String regId) {
    if(regId == null){
      return Response.status(Status.BAD_REQUEST).build();
    }
    else if(!regulations.containsKey(regId)){
      return Response.status(Status.NOT_FOUND).build();
    }
    else{
      return Response.ok().entity(createStringJsonFollowingOperandoConventions(regulations.get(regId))).build();
    }
  }
	
	@POST
	@Path("/regulations")
	@Consumes(MediaType.APPLICATION_JSON)
  public Response regulationsPost(@HeaderParam("service-ticket") String serviceTicket, String regulation)
  {
	  PrivacyRegulationInput input = getGsonOperando().fromJson(regulation, PrivacyRegulationInput.class);
	  if(input != null){
	    String id = UUID.randomUUID().toString();
	    PrivacyRegulation reg = new PrivacyRegulation(id, input.getLegislationSector(), input.getPrivateInformationSource(), input.getPrivateInformationType(), input.getAction(), input.getRequiredConsent());
	    if(regulations.putIfAbsent(id, reg) == null)
	    {
	      return Response.status(Status.CREATED).entity(id).build(); 
	    }
	    else{
	      // Should never hit this when using random UUIDs
	      return Response.status(Status.CONFLICT).build();
	    }
	  }
	  else{
	    return Response.status(Status.BAD_REQUEST).build();
	  }
  }
	
  @PUT
  @Path("/regulations/{reg-id}")
  @Consumes(MediaType.APPLICATION_JSON)
  public Response regulationsPut(@HeaderParam("service-ticket") String serviceTicket, String regulation, @PathParam("reg-id") String regId) {
    PrivacyRegulationInput input = getGsonOperando().fromJson(regulation, PrivacyRegulationInput.class);
    if (input != null && regId != null) {
      PrivacyRegulation reg = new PrivacyRegulation(regId, input.getLegislationSector(), input.getPrivateInformationSource(), input.getPrivateInformationType(), input.getAction(), input.getRequiredConsent());
      if(regulations.put(regId, reg) == null)
      {
        return Response.status(Status.CREATED).build(); 
      }
      else{
        return Response.status(Status.OK).build();
      }
    } else {
      return Response.status(Status.BAD_REQUEST).build();
    }
  }
  
  @DELETE
  @Path("/regulations/{reg-id}")
  public Response regulationsPut(@HeaderParam("service-ticket") String serviceTicket, @PathParam("reg-id") String regId) {
    if (regId != null) {
      if(regulations.containsKey(regId))
      {
        regulations.remove(regId);
        return Response.status(Status.OK).build(); 
      }
      else{
        return Response.status(Status.NOT_FOUND).build();
      }
    } else {
      return Response.status(Status.BAD_REQUEST).build();
    }
  }
  
  static void addRandomPolicy(int toAdd){
    String id = UUID.randomUUID().toString();
    Collection<AccessPolicy> access = new ArrayList<>();
    
    for(int i = 0; i < toAdd; i++){
      access.add(new AccessPolicy(
          Integer.toString(random.nextInt(random_max_int)), 
          Integer.toString(random.nextInt(random_max_int)), 
          Integer.toString(random.nextInt(random_max_int)),
          Integer.toString(random.nextInt(random_max_int)) 
        ));
    }    
    
    PrivacyPolicy policy = new PrivacyPolicy(id, access);
    policies.put(id, policy);  
  }
  
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	@Path("/OSP/{osp-id}/privacy-policy")
	public Response getPrivacyPolicy(@PathParam("osp-id") String ospId)
	{
    if(ospId == null){
      return Response.status(Status.BAD_REQUEST).build();
    }
    else if(!policies.containsKey(ospId)){
      return Response.status(Status.NOT_FOUND).build();
    }
    else{
      return Response.ok().entity(createStringJsonFollowingOperandoConventions(policies.get(ospId))).build();
    }
	}
	
	@POST
	@Path("/OSP/{osp-id}/privacy-policy")
  @Consumes(MediaType.APPLICATION_JSON)
  public Response privacyPolicyPost(@HeaderParam("service-ticket") String serviceTicket, String policy, @PathParam("osp-id") String ospId)
  {
	  PrivacyPolicy input = getGsonOperando().fromJson(policy, PrivacyPolicy.class);
    if(input != null && ospId != null){
      if(policies.putIfAbsent(ospId, input) == null)
      {
        return Response.status(Status.CREATED).build(); 
      }
      else{
        return Response.status(Status.CONFLICT).build();
      }
    }
    else{
      return Response.status(Status.BAD_REQUEST).build();
    }
  }
	
//	 @POST
//    @Path("/OSP/{osp-id}/privacy-policy/access-policy")
//    @Consumes(MediaType.APPLICATION_JSON)
//    public Response accessPolicyPost(@HeaderParam("service-ticket") String serviceTicket, String policy, @PathParam("osp-id") String ospId)
//    {
//	   if(ospId == null){
//	     return Response.status(Status.BAD_REQUEST).build();
//	   }
//	   else if(!policies.containsKey(ospId)){
//	     return Response.status(Status.NOT_FOUND).build();
//	   }
//	   else{
//      AccessPolicy input = getGsonOperando().fromJson(policy, AccessPolicy.class);
//      PrivacyPolicy privacyPolicy = policies.get(ospId);
//      if(input != null){
//        privacyPolicy.getPolicies().add(input);
//        return Response.status(Status.CREATED).build();
//      }
//      else{
//        return Response.status(Status.BAD_REQUEST).build();
//      }
//	   }
//    }
	 
	  @PUT
	  @Path("/OSP/{osp-id}/privacy-policy")
	  @Consumes(MediaType.APPLICATION_JSON)
	  public Response privacyPolicyPut(@HeaderParam("service-ticket") String serviceTicket, String policy, @PathParam("osp-id") String ospId)
	  {
	    PrivacyPolicy input = getGsonOperando().fromJson(policy, PrivacyPolicy.class);
	    if(ospId != null && input != null){
	      if(policies.put(ospId, input) == null)
	      {
	        return Response.status(Status.CREATED).build(); 
	      }
	      else{
	        return Response.status(Status.OK).build();
	      }
	    }
	    else{
	      return Response.status(Status.BAD_REQUEST).build();
	    }
	  }
	  
//	   @PUT
//	    @Path("/OSP/{osp-id}/privacy-policy/access-policy")
//	    @Consumes(MediaType.APPLICATION_JSON)
//	    public Response accessPolicyPut(@HeaderParam("service-ticket") String serviceTicket, String policy, @PathParam("osp-id") String ospId)
//	    {
//	     if(ospId == null){
//	       return Response.status(Status.BAD_REQUEST).build();
//	     }
//	     else if(!policies.containsKey(ospId)){
//	       return Response.status(Status.NOT_FOUND).build();
//	     }
//	     else{
//	      AccessPolicy input = getGsonOperando().fromJson(policy, AccessPolicy.class);
//	      PrivacyPolicy privacyPolicy = policies.get(ospId);
//	      if(input != null){
//	        privacyPolicy.getPolicies().add(input);
//	        return Response.status(Status.CREATED).build();
//	      }
//	      else{
//	        return Response.status(Status.BAD_REQUEST).build();
//	      }
//	     }
//	    }
	  
	  @DELETE
	   @Path("/OSP/{osp-id}/privacy-policy")
	  public Response privacyPolicyDelete(@HeaderParam("service-ticket") String serviceTicket, @PathParam("osp-id") String ospId) {
	    if (ospId != null) {
	      if(policies.containsKey(ospId))
	      {
	        policies.remove(ospId);
	        return Response.status(Status.OK).build(); 
	      }
	      else{
	        return Response.status(Status.NOT_FOUND).build();
	      }
	    } else {
	      return Response.status(Status.BAD_REQUEST).build();
	    }
	  }
	
	/**
	 * Convert a POJO to JSON using OPERANDO's default JSON format
	 */
	private static String createStringJsonFollowingOperandoConventions(Object object)
	{
		Gson gson = getGsonOperando();
		return gson.toJson(object);
	}

	/**
	 * Returns a Gson with OPERANDO's field naming policy.
	 */
	private static Gson getGsonOperando()
	{
		// According to our current conventions, JSON should be in snake_case.
		GsonBuilder builder = new GsonBuilder().setFieldNamingPolicy(FieldNamingPolicy.LOWER_CASE_WITH_UNDERSCORES);
		Gson gson = builder.create();
		return gson;
	}
	
	public static class PrivacyPolicy
	{
		private String ospPolicyId = "";
		private Collection<AccessPolicy> policies = new Vector<AccessPolicy>();
		
		public PrivacyPolicy(String ospPolicyId, Collection<AccessPolicy> policies)
		{
			super();
			this.ospPolicyId = ospPolicyId;
			this.policies = policies;
		}
		
		public String getOspPolicyId()
		{
			return ospPolicyId;
		}
		public void setOspPolicyId(String ospPolicyId)
		{
			this.ospPolicyId = ospPolicyId;
		}
		public Collection<AccessPolicy> getPolicies()
		{
			return policies;
		}
		public void setPolicies(Collection<AccessPolicy> policies)
		{
			this.policies = policies;
		}
	}
	
	public static class AccessPolicy
	{
		private String datauser = "";
		private String datasubjecttype = "";
		private String datatype = "";
		private String reason = "";

		public AccessPolicy(String datauser, String datasubjecttype, String datatype, String reason)
		{
			this.datauser = datauser;
			this.datasubjecttype = datasubjecttype;
			this.datatype = datatype;
			this.reason = reason;
		}

		public String getDatauser()
		{
			return datauser;
		}

		public void setDatauser(String datauser)
		{
			this.datauser = datauser;
		}

		public String getDatasubjecttype()
		{
			return datasubjecttype;
		}

		public void setDatasubjecttype(String datasubjecttype)
		{
			this.datasubjecttype = datasubjecttype;
		}

		public String getDatatype()
		{
			return datatype;
		}

		public void setDatatype(String datatype)
		{
			this.datatype = datatype;
		}

		public String getReason()
		{
			return reason;
		}

		public void setReason(String reason)
		{
			this.reason = reason;
		}
	}
}
