package bda;

import java.util.Vector;

public class BdaJob
{
	private String jobName = "";
	private String description = "";
	private String currentVersionNumber = "";
	private String costPerExecution = "";
	private Vector<BdaSchedule> schedules = new Vector<BdaSchedule>();
	private Vector<BdaExecution> executions = new Vector<BdaExecution>();

	public BdaJob(String jobName, String description, String currentVersionNumber, String costPerExecution, Vector<BdaExecution> executions,
			Vector<BdaSchedule> schedules)
	{
		super();
		this.jobName = jobName;
		this.description = description;
		this.currentVersionNumber = currentVersionNumber;
		this.costPerExecution = costPerExecution;
		this.executions = executions;
		this.schedules = schedules;
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
