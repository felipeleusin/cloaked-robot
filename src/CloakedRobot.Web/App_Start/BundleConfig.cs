using BundleTransformer.Core.Transformers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace CloakedRobot.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var cssTransformer = new CssTransformer();

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/commonStyles", cssTransformer).Include("~/Content/site.less"));
        }
    }
}