package bda;

import java.util.Vector;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import com.google.gson.FieldNamingPolicy;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

@Path("/bda")
public class Api
{
	private static final String OSP_AMI = "Ami";

	@GET
	@Path("/jobs/{job-id}/executions")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getExecutions()
	{
		Vector<BdaExecution> executions = new Vector<BdaExecution>();
		for (int i = 1; i < 10; i++)
		{
			String osp = "PDI";
			if (i % 2 == 0)
			{
				osp = "OCC";
			}
			executions.add(new BdaExecution("2016-09-0" + i, "versionNumber" + i, osp, "http://downloadLink" + i));
		}

		String json = createStringJsonFollowingOperandoConventions(executions);
		return Response.ok()
			.entity(json)
			.build();
	}

	@GET
	@Path("/jobs")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getJobs()
	{
		Vector<BdaJob> jobs = new Vector<BdaJob>();

		Vector<BdaExecution> executions = generateExecutions();
		Vector<BdaSchedule> schedules = generateSchedules();
		Vector<String> osps = generateOsps();

		jobs.addElement(new BdaJob("West London Care Needs", "An up to date report on the needs of clients, broken down by area", "v3",
				"http://", "£0.00", osps, schedules, executions));

		String json = createStringJsonFollowingOperandoConventions(jobs);
		return Response.ok()
			.entity(json)
			.build();
	}

	private Vector<String> generateOsps()
	{
		Vector<String> osps = new Vector<String>();
		osps.add(OSP_AMI);
		return osps;
	}

	private Vector<BdaExecution> generateExecutions()
	{
		Vector<BdaExecution> executions = new Vector<BdaExecution>();
		for (int j = 5; j > 0; j--)
		{
			String executionDate = "2017-01-17";
			if (j < 5)
			{
				executionDate = "2016-" + (8 + j) + "-16";
			}
			executions.add(new BdaExecution(executionDate, "v" + (1 + j / 2), OSP_AMI, "http://downloadLink" + j));
		}
		return executions;
	}

	private Vector<BdaSchedule> generateSchedules()
	{
		Vector<BdaSchedule> schedules = new Vector<BdaSchedule>();

		schedules.add(new BdaSchedule(OSP_AMI, "2016-9-16", "02:00", "month", "", "17th", "Indefinite"));
		
		return schedules;
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
