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
                        "~/Scripts/jquery-1.10.2.js",
                         "~/Scripts/jquery-ui-1.11.4.js"
                        ));

            // for validation
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.unobtrusive*"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-2.6.2"));

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



            //smartadmin js

            bundles.Add(new ScriptBundle("~/bundles/smartadmin").Include(
                      "~/Scripts/libs/app.config.js",
                      "~/Scripts/libs/demo.min.js",
                      "~/Scripts/libs/app.min.js",
                      "~/Scripts/libs/plugins/jquery-touch/jquery.ui.touch-punch.min.js",
                      "~/Scripts/libs/notification/SmartNotification.min.js",
                      "~/Scripts/libs/smartwidgets/jarvis.widget.min.js",
                      "~/Scripts/libs/plugins/jquery-validate/jquery.validate.min.js",
                      "~/Scripts/libs/plugins/masked-input/jquery.maskedinput.min.js",
                      "~/Scripts/libs/plugins/select2/select2.min.js",
                      "~/Scripts/libs/plugins/bootstrap-slider/bootstrap-slider.min.js",
                      "~/Scripts/libs/plugins/msie-fix/jquery.mb.browser.min.js",
                      "~/Scripts/libs/plugins/fastclick/fastclick.min.js",
                      "~/Scripts/libs/plugins/jquery-form/jquery-form.min.js",
                      "~/Scripts/libs/plugins/x-editable/jquery.mockjax.min.js",
                      //"~/Scripts/libs/plugins/x-editable/x-editable.min.js",
                      "~/Scripts/libs/speech/voicecommand.min.js",
                      "~/Scripts/libs/plugins/dropzone/dropzone.min.js"
                      
         
                ));


            // css:start

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/css/demo.min.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/css/lockscreen.min.css",
                      "~/Content/css/smartadmin-production.min.css",
                      "~/Content/css/smartadmin-rtl.min.css",
                      "~/Content/css/smartadmin-skins.min.css",
                      "~/Content/Site.css",
                       "~/Content/css/jquery.ui.timepicker.css"
                       ));

            // bootstrap dialog

            bundles.Add(new StyleBundle("~/Content/bootstrap-dialog-css").Include(
                    "~/Content/bootstrap-dialog.min.css"));


           
        }
    }
}
