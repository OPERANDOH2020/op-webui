package bda.Model;

public class Execution
{
	private String executionDate = null;
	private String versionNumber = "";
	private String ospScheduled = "";
	private String downloadLink = "";
	
	public Execution(String executionDate, String versionNumber, String ospScheduled, String downloadLink)
	{
		super();
		this.executionDate = executionDate;
		this.versionNumber = versionNumber;
		this.ospScheduled = ospScheduled;
		this.downloadLink = downloadLink;
	}
	
	public String getExecutionDate()
	{
		return executionDate;
	}
	public void setExecutionDate(String executionDate)
	{
		this.executionDate = executionDate;
	}
	public String getVersionNumber()
	{
		return versionNumber;
	}
	public void setVersionNumber(String versionNumber)
	{
		this.versionNumber = versionNumber;
	}
	public String getOspScheduled()
	{
		return ospScheduled;
	}
	public void setOspScheduled(String ospScheduled)
	{
		this.ospScheduled = ospScheduled;
	}
	public String getDownloadLink()
	{
		return downloadLink;
	}
	public void setDownloadLink(String downloadLink)
	{
		this.downloadLink = downloadLink;
	}
}
