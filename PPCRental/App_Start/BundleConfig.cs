using System.Web;
using System.Web.Optimization;

namespace PPCRental
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css","~/Content/index.css","~/Content/carousel.css",
                      "~/Content/Site.css"));
            bundles.Add(new StyleBundle("~/fileinput/css").Include(
                      "~/Content/bootstrap-fileinput/css/fileinput-rtl.css",
                      "~/Content/bootstrap-fileinput/css/fileinput-rtl.min.css",
                      "~/Content/bootstrap-fileinput/css/fileinput.css",
                      "~/Content/bootstrap-fileinput/css/fileinput.min.css"));
        }
    }
}
