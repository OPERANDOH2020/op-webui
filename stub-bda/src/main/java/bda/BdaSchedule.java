package bda;

public class BdaSchedule
{
	private String ospScheduled = "";
	private String startDate = "";
	private String startTime = "";
	private String repeatIntervalUnit = "";
	private String repeatIntervalValue = "";
	private String repeatOn = "";
	private String storagePeriod = "";
	
	public BdaSchedule(String ospScheduled, String startDate, String startTime, String repeatIntervalUnit, String repeatIntervalValue, String repeatOn, String storagePeriod)
	{
		super();
		this.ospScheduled = ospScheduled;
		this.startDate = startDate;
		this.startTime = startTime;
		this.repeatIntervalUnit = repeatIntervalUnit;
		this.repeatIntervalValue = repeatIntervalValue;
		this.repeatOn = repeatOn;
		this.storagePeriod = storagePeriod;
	}
	
	public String getOspScheduled()
	{
		return ospScheduled;
	}

	public void setOspScheduled(String ospScheduled)
	{
		this.ospScheduled = ospScheduled;
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
	public String getStoragePeriod()
	{
		return storagePeriod;
	}
	public void setStoragePeriod(String storagePeriod)
	{
		this.storagePeriod = storagePeriod;
	}
}
