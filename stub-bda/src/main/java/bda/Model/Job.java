package bda.Model;

import java.util.UUID;
import java.util.Vector;

public class Job
{
	private UUID id;
	private String jobName = "";
	private String description = "";
	private String currentVersionNumber = "";
	private String definitionLocation = "";
	private Money costPerExecution = null;
	private Vector<String> osps = new Vector<String>();
	private Vector<Schedule> schedules = new Vector<Schedule>();
	private Vector<Execution> executions = new Vector<Execution>();
	
	public Job(UUID id, String jobName, String description, String currentVersionNumber, String definitionLocation, Money costPerExecution, Vector<String> osps,
			Vector<Schedule> schedules, Vector<Execution> executions)
	{
		super();
		this.setId(id);
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

	public Money getCostPerExecution()
	{
		return costPerExecution;
	}

	public void setCostPerExecution(Money costPerExecution)
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

	public Vector<Schedule> getSchedules()
	{
		return schedules;
	}

	public void setSchedules(Vector<Schedule> schedules)
	{
		this.schedules = schedules;
	}

	public Vector<Execution> getExecutions()
	{
		return executions;
	}

	public void setExecutions(Vector<Execution> executions)
	{
		this.executions = executions;
	}

	public UUID getId() {
		return id;
	}

	public void setId(UUID id) {
		this.id = id;
	}
}
