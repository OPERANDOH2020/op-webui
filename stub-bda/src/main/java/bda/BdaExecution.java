package bda;

public class BdaExecution
{
	private String executionDate = null;
	private String versionNumber = "";
	private String downloadLink = "";
	
	public BdaExecution(String executionDate, String versionNumber, String downloadLink)
	{
		super();
		this.executionDate = executionDate;
		this.versionNumber = versionNumber;
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
	public String getDownloadLink()
	{
		return downloadLink;
	}
	public void setDownloadLink(String downloadLink)
	{
		this.downloadLink = downloadLink;
	}
}
