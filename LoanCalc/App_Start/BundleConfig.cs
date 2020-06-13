using System.Web;
using System.Web.Optimization;

namespace LoanCalc {
    public class BundleConfig {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/Content/bootstrap.css",
                "~/Content/prism.css",
                "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/prism.js",
                "~/Scripts/loan-calc.js"));
        }
    }
}
