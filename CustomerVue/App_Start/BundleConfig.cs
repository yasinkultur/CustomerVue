using CustomerVue.Code;
using System.Web;
using System.Web.Optimization;
using dotless.Core;

namespace CustomerVue
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Script
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.ajaxq.js"
                //"~/Scripts/moment.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/vuejs").Include(
                "~/Scripts/vue.js",
                "~/Scripts/vue-router.js"));

            // Vue
            bundles.Add(new VueBundle("~/bundles/vue/components").Include(
                "~/Vue/Components/*.vue"));

            bundles.Add(new VueBundle("~/bundles/vue/apps").Include(
                "~/Vue/Apps/*.vue"));

            // Style
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/font-awesome.css"));

            bundles.Add(new LessBundle("~/Content/less").Include(
                "~/Content/Start.less"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
