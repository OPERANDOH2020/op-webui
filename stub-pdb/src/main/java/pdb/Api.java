package pdb;

import eu.operando.api.model.DtoPrivacyRegulation.PrivateInformationTypeEnum;
import eu.operando.api.model.DtoPrivacyRegulation.RequiredConsentEnum;
import eu.operando.api.model.PrivacyPolicy;
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
	@Path("/OSP")
	public Response getPrivacyPolicy()
	{
		Vector<PrivacyPolicy> policies = new Vector<PrivacyPolicy>();
		
		PrivacyPolicy policy1 =
				new PrivacyPolicy("id", "terms");
		PrivacyPolicy policy2 =
				new PrivacyPolicy("id", "terms");
		PrivacyPolicy policy3 =
				new PrivacyPolicy("id", "terms");
		
		policies.add(policy1);
		policies.add(policy2);
		policies.add(policy3);
		
		String json = createStringJsonFollowingOperandoConventions(policies);
		
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
}
