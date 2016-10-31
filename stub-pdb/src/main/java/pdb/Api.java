package pdb;

import eu.operando.api.model.DtoPrivacyRegulation.PrivateInformationTypeEnum;
import eu.operando.api.model.DtoPrivacyRegulation.RequiredConsentEnum;
import eu.operando.api.model.PrivacyRegulation;

import java.util.Vector;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import com.google.gson.FieldNamingPolicy;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

@Path("/api")
public class Api
{
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	@Path("/regulations")
	public Response getRegulations()
	{
		Vector<PrivacyRegulation> regulations = new Vector<PrivacyRegulation>();
		
		PrivacyRegulation regulation1 =
				new PrivacyRegulation("regId1", "sector X", "privateInformationSource1", PrivateInformationTypeEnum.BEHAVIOURAL, "actionA", RequiredConsentEnum.IN);
		PrivacyRegulation regulation2 =
				new PrivacyRegulation("regId2", "sector Y", "privateInformationSource2", PrivateInformationTypeEnum.BELIEFS, "actionB", RequiredConsentEnum.OUT);
		PrivacyRegulation regulation3 =
				new PrivacyRegulation("regId3", "sector Z", "privateInformationSource3", PrivateInformationTypeEnum.GEOGRAPHIC, "actionC", RequiredConsentEnum.IN);
		
		regulations.add(regulation1);
		regulations.add(regulation2);
		regulations.add(regulation3);
		
		String json = createStringJsonFollowingOperandoConventions(regulations);
		
		return Response.ok().entity(json).build();
	}
	
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	@Path("/OSP/{osp-id}/privacy-policy")
	public Response getPrivacyPolicy()
	{
		Vector<AccessPolicy> policies = new Vector<AccessPolicy>();
		
		AccessPolicy policy1 = new AccessPolicy("datauser1", "datasubjecttype1", "datatype1", "reason1");
		AccessPolicy policy2 = new AccessPolicy("datauser2", "datasubjecttype2", "datatype2", "reason2");
		AccessPolicy policy3 = new AccessPolicy("datauser3", "datasubjecttype3", "datatype3", "reason3");
		
		policies.add(policy1);
		policies.add(policy2);
		policies.add(policy3);
		
		PrivacyPolicy policy = new PrivacyPolicy("Ami", policies);
		
		String json = createStringJsonFollowingOperandoConventions(policy);
		
		return Response.ok().entity(json).build();
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
	
	public class PrivacyPolicy
	{
		private String ospPolicyId = "";
		private Vector<AccessPolicy> policies = new Vector<AccessPolicy>();
		
		public PrivacyPolicy(String ospPolicyId, Vector<AccessPolicy> policies)
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
		public Vector<AccessPolicy> getPolicies()
		{
			return policies;
		}
		public void setPolicies(Vector<AccessPolicy> policies)
		{
			this.policies = policies;
		}
	}
	
	public class AccessPolicy
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
