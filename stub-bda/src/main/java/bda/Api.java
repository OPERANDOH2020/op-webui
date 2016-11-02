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
	private static final String OSP_1 = "OCC";
	private static final String OSP_2 = "PDI";
	private static final String OSP_3 = "ITI";
	
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
		
		for (int i=1; i<=3; i++)
		{
			Vector<BdaExecution> executions = generateExecutions(i);
			Vector<BdaSchedule> schedules = generateSchedules(i);
			Vector<String> osps = generateOsps(i);
			
			jobs.addElement(new BdaJob("Job" + i, "Description" + i, "v1." + (3-i), "http://", "�" + i + ".00", osps, schedules, executions));
		}

		String json = createStringJsonFollowingOperandoConventions(jobs);
		return Response.ok()
			.entity(json)
			.build();
	}

	private Vector<String> generateOsps(int i)
	{
		Vector<String> osps = new Vector<String>();
		if (i == 1)
		{
			osps.add(OSP_1);
			osps.add(OSP_2);
		}
		else if (i == 2)
		{
			osps.add(OSP_3);
		}
		else
		{
			osps.add(OSP_1);
		}
		return osps;
	}

	private Vector<BdaExecution> generateExecutions(int i)
	{
		Vector<BdaExecution> executions = new Vector<BdaExecution>();
		for (int j = 1; j <= 5; j++)
		{
			String osp = "PDI";
			if (i % 2 == 0)
			{
				osp = "OCC";
			}
			executions.add(new BdaExecution("2016-09-0" + (i+j), "versionNumber" + j, osp, "http://downloadLink" + j));
		}
		return executions;
	}

	private Vector<BdaSchedule> generateSchedules(int i)
	{
		Vector<BdaSchedule> schedules = new Vector<BdaSchedule>();
		for (int j = 1; j <= 5; j++)
		{
			String repeatIntervalUnit = "day";
			String repeatOn = "-";
			if (j == 2)
			{
				repeatIntervalUnit = "week";
				repeatOn = "Mon, Wed, Fri";
			}
			else if (j == 3)
			{
				repeatIntervalUnit = "month";
				repeatOn = "1st";
			}
			else if (j == 4)
			{
				repeatIntervalUnit = "year";
				repeatOn = "1st Jan";
			}
			
			String osp = OSP_1;
			if (i == 2)
			{
				osp = OSP_2;
			}
			else if (i == 3)
			{
				osp = OSP_3;
			}
			
			schedules.add(new BdaSchedule(osp, "2017-01-0" + (i+j-1), "19:" + j + "0", repeatIntervalUnit, "" + j, repeatOn, "Indefinite"));
		}
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