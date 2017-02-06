<%@ Application Language="C#" %>
<%@ Import Namespace="ReportRESTsite" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }

    static void RegisterRoutes(RouteCollection routes)
    {
        //routes.MapPageRoute("Report", "Report", "/Report.aspx");
    }

</script>
