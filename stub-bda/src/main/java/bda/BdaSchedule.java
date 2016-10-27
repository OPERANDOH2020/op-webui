package bda;

public class BdaSchedule
{
	private String startDate = "";
	private String startTime = "";
	private String repeatIntervalUnit = "";
	private String repeatIntervalValue = "";
	private String repeatOn = "";
	
	public BdaSchedule(String startDate, String startTime, String repeatIntervalUnit, String repeatIntervalValue, String repeatOn)
	{
		super();
		this.startDate = startDate;
		this.startTime = startTime;
		this.repeatIntervalUnit = repeatIntervalUnit;
		this.repeatIntervalValue = repeatIntervalValue;
		this.repeatOn = repeatOn;
	}
	
	public String getStartDate()
	{
		return startDate;
	}
	public void setStartDate(String startDate)
	{
		this.startDate = startDate;
	}
	public String getStartTime()
	{
		return startTime;
	}
	public void setStartTime(String startTime)
	{
		this.startTime = startTime;
	}
	public String getRepeatIntervalUnit()
	{
		return repeatIntervalUnit;
	}
	public void setRepeatIntervalUnit(String repeatIntervalUnit)
	{
		this.repeatIntervalUnit = repeatIntervalUnit;
	}
	public String getRepeatIntervalValue()
	{
		return repeatIntervalValue;
	}
	public void setRepeatIntervalValue(String repeatIntervalValue)
	{
		this.repeatIntervalValue = repeatIntervalValue;
	}
	public String getRepeatOn()
	{
		return repeatOn;
	}
	public void setRepeatOn(String repeatOn)
	{
		this.repeatOn = repeatOn;
	}
}
