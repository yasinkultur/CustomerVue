using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace CustomerVue.Code
{
    public static class Extensions
    {
        public static IHtmlString VueRender(this HtmlHelper htmlHelper, string bundleVirtualPath)
        {
            //if (htmlHelper.ViewContext.HttpContext.IsDebuggingEnabled)
            //{
            //    // Break the bundle open and inline each file into the page
            //    StringBuilder sb = new StringBuilder();

            //    BundleContext bundleContext = new BundleContext(htmlHelper.ViewContext.HttpContext, BundleTable.Bundles, bundleVirtualPath);
            //    Bundle bundle = BundleTable.Bundles.Single(b => b.Path.Equals(bundleVirtualPath, StringComparison.InvariantCultureIgnoreCase));

            //    foreach (BundleFile bf in bundle.EnumerateFiles(bundleContext))
            //    {
            //        sb.AppendLine(File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(bf.IncludedVirtualPath)));
            //    }

            //    return new MvcHtmlString(sb.ToString());
            //}
            //else
            //{
                // Render a script include (the Vue bundle transform will kick in)
                return Scripts.Render(bundleVirtualPath);
            //}
        }
    }
}