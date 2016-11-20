using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",

                         "~/Scripts/jquery.js",
                          "~/Scripts/bootstrap.min.js",
                      "~/Scripts/gritter-conf.js",
                      "~/Scripts/gritter-conf.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/gritter-conf.js",
                      "~/Scripts/gritter-conf.js",
                      "~/Scripts/jquery.js",
                       "~/Scripts/jquery-1.8.3.min.js",
                        "~/Scripts/jquery.dcjqaccordion.2.7.js",
                         "~/Scripts/jquery.scrollTo.min.js",
                          "~/Scripts/jquery.sparkline.js",
                           "~/Scripts/common-scripts.js",
                            "~/Scripts/jquery.gritter.js",
                             "~/Scripts/gritter-conf.js",

                              "~/Scripts/sparkline-chart.js",
                             "~/Scripts/zabuto_calendar.js",


                      "~/Scripts/respond.js"));







            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                       "~/Content/icons.css",
                      "~/Content/font-awesome.css",
                      "~/Content/zabuto_calendar.css",
                      "~/Content/jquery.gritter.css",
                      "~/Content/style.css",
                      "~/Content/style-responsive.css",
                      "~/Content/site.css"));






            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
   "~/Content/bootstrap.css",
   "~/Content/site.css"));
        }
    }
}
