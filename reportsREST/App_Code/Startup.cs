using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReportRESTsite.Startup))]
namespace ReportRESTsite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
