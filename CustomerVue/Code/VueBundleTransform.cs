using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Optimization;

namespace CustomerVue.Code
{
    public class VueBundleTransform : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            StringBuilder sb = new StringBuilder();

            foreach (BundleFile file in response.Files)
            {
                string fileContents = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(file.IncludedVirtualPath));

                // Extract the template
                Match templateMatch = Regex.Match(fileContents, "<script\\s*type=\"text/template\"\\s*id=\"(.*?)\">(.*?)</script>", RegexOptions.Singleline | RegexOptions.IgnoreCase);

                if (templateMatch == null)
                {
                    throw new InvalidOperationException("Could not find <script type=\"text/template\" id=\"xyz\"> section in Vue file.");
                }

                string templateId = templateMatch.Groups[1].Value;
                string templateHtml = templateMatch.Groups[2].Value;
                string encodedTemplateHtml = templateHtml.Trim().Replace(Environment.NewLine, "").Replace("'", "\\'");

                // Get rid of excess whitespace
                encodedTemplateHtml = Regex.Replace(encodedTemplateHtml, @"\s{2,}", " ");

                // Extract the script and insert the template
                Match javaScriptMatch = Regex.Match(fileContents, "<script\\s*type=\"text/javascript\"\\s*>(.*?)</script>", RegexOptions.Singleline | RegexOptions.IgnoreCase);

                if (javaScriptMatch == null)
                {
                    throw new InvalidOperationException("Could not find <script type=\"text/javascript\"> section in Vue file.");
                }

                sb.Append(javaScriptMatch.Groups[1].Value.Replace("#" + templateId, encodedTemplateHtml));
            }

            response.Content = sb.ToString();
            response.ContentType = "text/javascript; charset=utf-8";
        }
    }
}