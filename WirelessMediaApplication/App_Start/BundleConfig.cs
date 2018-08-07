using System.Web;
using System.Web.Optimization;

namespace WirelessMediaApplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            /***************************** SKRIPTE ******************************/

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
            "~/Scripts/angular.js",
            "~/Scripts/angular-loader.js",
            "~/Scripts/angular-message-format.js",
            "~/Scripts/angular-messages.js",
            "~/Scripts/angular-resource.js",
            "~/Scripts/angular-route.js",
            "~/Scripts/angular-sanitize.js",
            "~/Scripts/angular-aria.js",
            "~/Scripts/angular-animate.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/SharedAngular").Include(
                    "~/Scripts/SharedAngular.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-upload").Include(
                    "~/Scripts/angular-upload.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/assets-cache").Include(
                    "~/Scripts/assets-cache.js"));

            bundles.Add(new ScriptBundle("~/bundles/bower-angular-material").Include(
                     "~/Scripts/bower-angular-material.js"));

            bundles.Add(new ScriptBundle("~/bundles/PocetnaStrana").Include(
               "~/Scripts/Controllers/PocetnaStrana.js"));

            bundles.Add(new ScriptBundle("~/bundles/IzmenaProizvoda").Include(
             "~/Scripts/Controllers/IzmenaProizvoda.js"));

            bundles.Add(new ScriptBundle("~/bundles/UnosNovogProizvoda").Include(
          "~/Scripts/Controllers/UnosNovogProizvoda.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            /******************************** STILOVI ************************************/
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/angularcss").Include(
                    "~/Content/angular-csp.css",
                    "~/Content/angular-material.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrapicons").Include(
                    "~/Content/bootstrap.no-icons.min.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrapicons").Include(
               "~/Content/bootstrap.no-icons.min.css"));
        }
    }
}
