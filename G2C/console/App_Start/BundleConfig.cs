using System.Web;
using System.Web.Optimization;

namespace Operando_AdministrationConsole
{
    public class BundleConfig
    {
        // Per ulteriori informazioni sulla creazione di bundle, visitare http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Utilizzare la versione di sviluppo di Modernizr per eseguire attività di sviluppo e formazione. Successivamente, quando si è
            // pronti per passare alla produzione, utilizzare lo strumento di compilazione disponibile all'indirizzo http://modernizr.com per selezionare solo i test necessari.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/operando/global-mandatory/css").Include(
                      "~/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                      "~/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                      "~/assets/global/plugins/bootstrap/css/bootstrap.min.css",
                      "~/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css"));

            bundles.Add(new StyleBundle("~/operando/global-theme/css").Include(
                      "~/assets/global/css/components.css",
                      "~/assets/global/css/plugins.css"));

            bundles.Add(new StyleBundle("~/operando/global-layout/css").Include(
                      "~/assets/layouts/operando/css/layout.css",
                      "~/assets/layouts/operando/css/themes/default.css",
                      "~/assets/layouts/operando/css/custom.css"));


            bundles.Add(new ScriptBundle("~/operando/plugins/old-ie").Include(
                        "~/assets/global/plugins/respond.min.js",
                        "~/assets/global/plugins/excanvas.min.js",
                        "~/assets/global/plugins/ie8.fix.min.js"));

            bundles.Add(new ScriptBundle("~/operando/plugins/core").Include(
                        "~/assets/global/plugins/jquery.min.js",
                        "~/assets/global/plugins/bootstrap/js/bootstrap.min.js",
                        "~/assets/global/plugins/js.cookie.min.js",
                        "~/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                        "~/assets/global/plugins/jquery.blockui.min.js",
                        "~/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js"));

            bundles.Add(new ScriptBundle("~/operando/scripts/global-theme").Include(
                        "~/assets/global/scripts/app.min.js"));

            bundles.Add(new ScriptBundle("~/operando/scripts/layout-theme").Include(
                        "~/assets/layouts/operando/scripts/layout.min.js",
                        "~/assets/layouts/operando/scripts/demo.min.js",
                        "~/assets/layouts/global/scripts/quick-sidebar.min.js",
                        "~/assets/layouts/global/scripts/quick-nav.min.js"));
        }
    }
}
