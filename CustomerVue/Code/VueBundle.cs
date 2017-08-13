using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace CustomerVue.Code
{
    public class VueBundle : Bundle
    {
        public VueBundle(string virtualPath) : base(virtualPath, new VueBundleTransform(), new JsMinify()) { }
        public VueBundle(string virtualPath, string cdnPath) : base(virtualPath, cdnPath, new VueBundleTransform(), new JsMinify()) { }
    }
}