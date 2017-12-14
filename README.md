# op-webui
For the modules in the Web UI container:
 * Administration and Management Console (AMC)
 ** found in G2C Operando-AdministrationConsole
 * Report Generator (RG)

You can find a description of OPERANDO's architecture on the [project website](https://www.operando.eu). You can find detailed specifications and descriptions of each of the modules in this repository in D5.5 (to be relased in October 2017) of [OPERANDO's public deliverables](https://www.operando.eu/servizi/moduli/moduli_fase01.aspx?mp=1&fn=6&Campo_78=&Campo_126=68&AggiornaDB=search&moduli1379178994=&__VIEWSTATEGENERATOR=D6660DC7&__EVENTVALIDATION=/wEWCAKInYjvBwK46/eoCgLW6PifAQLM6NSfAQLP6LicAQLM6NifAQLPm7uVCQKtvouLDQGIwuPU0XcXVk7W8FmpEwz15iKL).

## Reporting an issue
To report an issue, please use GitHub's built-in issue-tracking system for this repository, or send an email to bug-report@operando.eu.

## Contributing code
If you'd like to contribute code, we'd be happy to have your support, so please contact us at os-contributions@operando.eu! You can find some examples of how you might help us on the [contributions page](https://www.operando.eu) of our website.

N.B. The copyright for any code will be owned by the OPERANDOH2020 organisation, and can therefore be used by any of the partner organisations that make up the consortium in other applications.

## Functional Description of Modules
### AMC 
The G2C Administration and Management Console (AMC) is the graphical user interface that allows every kind of user (End users, OSP Administrators, PSP Administrators and Analysts, Regulators) to manage every feature that they are allowed to, using a simple interface.<br />
The G2C Administration and Management Console appears like a series of web pages, split into a few sections containing functional parts.<br />
The graphical interface is implemented with ASP.NET MVC and C#. Every page is made of a Model, with Views and Controls to determine what to show in the page.<br />
The G2C Administration and Management Console is a graphic module developed with C# in an ASP.NET MVC platform.  It exploits Javascript, JQuery, HTML5 and CSS3 to grant a responsive design.<br />
### RG
The Report Generator module is used to generate reports upon request.<br />
The Report Generator module is composed of various parts which can interact among them: <br />
•	Report Design: In this module, an analyst can define and model a report. In detail, he has to define what the data sources are, how to extract data and how to represent them in graphical or tabular form. <br />
At the end of the process, an XML file will be produced that contains the complete report definition. This module will be a graphical tool installed to the developer’s desktop (client side). <br />
•	Report Engine: This component is server-side and “executes” the report, returning the result to the user who has requested it. <br />
•	Report Scheduler: The Report Generator module allows a user (PSP user or OSP user) to schedule the automatic generation of reports in PDF format. This application read the information relating to the scheduling of the various reports and automatically generates the report documents (pdf) and save them in a specific folder. These documents can be downloaded by PSP or OSP users.<br />
•	Report REST Service: This is a REST Web Application that receives HTTP GET call and, if it is valid, it returns the report in a base64 string inside a JSON structure. Any other module or service that wants to access to the Report Engine functionality must use this service.<br />
•	MySql Report Database: All information about reports management are saved inside a MySql database. This information includes:<br />
•	Reports list: Stores information like Name of the report, Description, URL, Parameters, etc.<br />
•	Request: Stores all the demands made by users for new reports.<br />
•	Results: Stores the results generated by the Report Scheduler (Report file name, Execution date, etc).<br />
•	Schedules: Stores information relating to scheduling and used by Report Scheduler.<br />


## Installation Instructions
### AMC
G2C Administration and Management Console can be downloaded from GitHub repository at address https://github.com/OPERANDOH2020/op-webui.git <br />
After downloading the source, you can open the solution file using Visual Studio Express for Web 2015 and compile / run the project. Visual Studio will automatically create a local web server capable of running the site.<br />
Alternatively, it will be necessary to configure a site on IIS 8 (or above) on which it will be sufficient to copy the downloaded sources and configure the key inside web.config.<br />
### RG
Report Generator is a module composed of different parts, here I will explain how to install and run each of them.<br />
BIRT Viewer installation:
1.	Install JAVA JDK 7.X
2.	Install Tomcat 6.0
3.	Download the zip file with the BIRT report engine runtime from BIRT engine. The file is named birt-runtime-version#.zip.
4.	 Unzip the file in a staging area.
5.	Look under the birt-runtime- directory and locate the "Web Viewer Example" directory.
6.	Copy the Web Viewer Example directory to the webapps directory of your Tomcat installation. For ease of reference, rename the directory to "birt-viewer".
7.	Download mysql driver connector 5.1.40 and put it inside \WEB-INF\lib
8.	 Stop, then restart Tomcat.
9.	Display the Tomcat manager application to check that the viewer is deployed: http://localhost:8080/manager/html.
10.	Verify that birt-viewer is listed as an application, then click on the birt-viewer link.
11.	A page confirming that the BIRT viewer has been installed should be displayed. Click on the link labeled "View Example" to confirm that your installation is working properly.
12.	The BIRT Viewer requires that cookies be enabled.
13.	Configure, inside WEB-INFO/web.xml, this param-name:
a.	userAapiBasePath: AAPI user URL endpoint.
b.	serviceId: Report service id.
c.	stHeaderName: Service ticket name in HTTP Header.
14.	Edit file WEB-INF\classes\it\progettidiimpresa\ssc\filter\SSCReportFilterOperando.class taking the code from 

BIRT Report Designer:
1.	Download and install BIRT Report Designer. This Download includes the BIRT Reporting Framework, Eclipse SDK, GEF and EMF and Axis downloads. It includes everything you need to get started.

MySql Server:
1.	Download and install MySql 5.1.73.
2.	Download the scripts for the creation of working tables of the Report Generator module. Inside the folder operando_data you will find the sql script to restore the database with demo OSP’s data. Inside the folder operando_report you will find the sql script to restore the database with report manager table.
3.	Configure, inside Web.config in Operando Management Console, the connection string to MySql operando_report database inside “MySQLConnection” key.

Report Scheduler:
1.	Download OPERANDO Web Console from https://github.com/OPERANDOH2020/op-webui.git
2.	Build the EXE inside Operando-AdministrationConsole\ExecuteSchedule
3.	Place the EXE on a Windows server that can connect to the MySql server where there are the managers data of the report tables
4.	Set the connection string to MySql server in the app.config inside "MySQLConnection" key.
5.	Set the Task Scheduler of the operating system running the EXE.
6.	Set the "pathSave" key with the location to save the downloaded files inside app.config. PathSave variable should be a folder end with "\reportSavePath" and must be within the webapp Operando-AdministrationConsole.

Report Rest Service:
1.	Inside repository https://github.com/OPERANDOH2020/op-webui.git there is a folder named reportsREST_WP that contains the code of Report Rest Service. This service makes HTTP GET calls to BIRT Viewer, read response, encapsulates it inside a JSON and returns it to the caller.
2.	This module is configurable via Web.config, inside root folder of web site. Contains following keys: 
•	MySQLConnection: Connection string to MySql operando_report database.
•	userAapiBasePath: AAPI user URL endpoint.
•	serviceId: Report service id.
•	stHeaderName: Service ticket name in HTTP Header.

## Usage Instructions
### AMC
Interactions with this form all occur via Web UI.
The module is a modern and responsive web application, so the user could interact with it as with any other web or mobile site using a web browser.  
### RG
Reports can be created using BIRT Report Designer. Once the report is created, it must be placed inside BIRT Viewer. After this, you can add these reports inside Operando Management Console using the section dedicated to reports management (PspAdmin/ReportsConfig and OspAdmin/Reports). <br />
Through the web UI console you can configure the scheduling of the report, set which OSPs the report should be visible to, change the input parameters and see the results.<br />
Alternatively, reports can be accessed through Report Rest Service application. You have to make HTTP GET call putting in the header the service ticket and in the query string the parameters:<br />
•	_reportId: specify the ID of the report (inside MySql table t_report_mng_list) to download.<br />
•	_format: specify the output format (HTML or PDF).<br />
•	paramName: report parameters that are designated in the design mode can be passed as URL parameters by entering the paramName=value syntax.

## Future Plans
### AMC 
Improvements, enhancements and bug fixing.
### RG
Improvements, enhancements and bug fixing.
