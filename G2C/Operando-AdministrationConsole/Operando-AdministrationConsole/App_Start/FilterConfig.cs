using System.Web;
using System.Web.Mvc;

namespace Operando_AdministrationConsole
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
