using System.Web;
using System.Web.Optimization;

namespace ProjectManagerApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.js"));

            // for validation
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.unobtrusive*"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                    //   "~/Scripts/bootstrap-dialog.js",
                        "~/Scripts/bootstrap-dialog.min.js",
                      "~/Scripts/respond.js"));

            // jqueryajaxform

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //    "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryajaxform").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                         "~/Scripts/jquery-1.10.2.js"
                         ));
          

            //datetimepicker
            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include(
                 "~/Scripts/moment.js",
                "~/Scripts/bootstrap-datetimepicker.js"));

           
            // css:start

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-dialog-css").Include(
                    "~/Content/bootstrap-dialog.min.css"));


           
        }
    }
}
