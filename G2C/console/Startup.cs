using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Operando_AdministrationConsole.Startup))]
namespace Operando_AdministrationConsole
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
