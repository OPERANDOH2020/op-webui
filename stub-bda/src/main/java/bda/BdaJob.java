package bda;

import java.util.Vector;

public class BdaJob
{
	private String jobName = "";
	private String description = "";
	private String currentVersionNumber = "";
	private String definitionLocation = "";
	private String costPerExecution = "";
	private Vector<String> osps = new Vector<String>();
	private Vector<BdaSchedule> schedules = new Vector<BdaSchedule>();
	private Vector<BdaExecution> executions = new Vector<BdaExecution>();
	
	public BdaJob(String jobName, String description, String currentVersionNumber, String definitionLocation, String costPerExecution, Vector<String> osps,
			Vector<BdaSchedule> schedules, Vector<BdaExecution> executions)
	{
		super();
		this.jobName = jobName;
		this.description = description;
		this.currentVersionNumber = currentVersionNumber;
		this.definitionLocation = definitionLocation;
		this.costPerExecution = costPerExecution;
		this.osps = osps;
		this.schedules = schedules;
		this.executions = executions;
	}

	public String getDefinitionLocation()
	{
		return definitionLocation;
	}

	public void setDefinitionLocation(String definitionLocation)
	{
		this.definitionLocation = definitionLocation;
	}

	public String getJobName()
	{
		return jobName;
	}

	public void setJobName(String jobName)
	{
		this.jobName = jobName;
	}

	public String getDescription()
	{
		return description;
	}

	public void setDescription(String description)
	{
		this.description = description;
	}

	public String getCurrentVersionNumber()
	{
		return currentVersionNumber;
	}

	public void setCurrentVersionNumber(String currentVersionNumber)
	{
		this.currentVersionNumber = currentVersionNumber;
	}

	public String getCostPerExecution()
	{
		return costPerExecution;
	}

	public void setCostPerExecution(String costPerExecution)
	{
		this.costPerExecution = costPerExecution;
	}

	public Vector<String> getOsps()
	{
		return osps;
	}

	public void setOsps(Vector<String> osps)
	{
		this.osps = osps;
	}

	public Vector<BdaSchedule> getSchedules()
	{
		return schedules;
	}

	public void setSchedules(Vector<BdaSchedule> schedules)
	{
		this.schedules = schedules;
	}

	public Vector<BdaExecution> getExecutions()
	{
		return executions;
	}

	public void setExecutions(Vector<BdaExecution> executions)
	{
		this.executions = executions;
	}
}
