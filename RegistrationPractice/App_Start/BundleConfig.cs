using System.Web;
using System.Web.Optimization;

namespace RegistrationPractice
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                "~/Scripts/umd/popper-min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/mdb").Include(
                "~/Scripts/mdb/mdb.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                    "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css1").Include(
                      "~/Content/login.css", "~/Content/font-awesome.css", "~/Content/jquery-ui.css"));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                      "~/Scripts/userscript/AdminMenu.js",
                      "~/Scripts/userscript/PreviewImage.js",
                      "~/Scripts/userscript/expandmenu.js",
                      "~/Scripts/userscript/button.js",
                      "~/Scripts/userscript/PreviewImage.js",
                      "~/Scripts/userscript/token.js",
                      "~/Scripts/userscript/paging.js"


                      ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryunobtrusive").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js"
            ));

        }
    }
}
