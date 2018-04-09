using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace DeveloopPrueba.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // MDB Styles
            bundles.Add(new StyleBundle("~/Content/MDBStyles")
                .Include("~/Content/bootstrap*")
                .Include("~/Content/mdb*"));

            // MDB Scripts.
            bundles.Add(new ScriptBundle("~/Scripts/MDBScripts")
                .Include("~/Scripts/bootstrap*")
                .Include("~/Scripts/jquery-*")
                .Include("~/Scripts/mdb*")
                .Include("~/Scripts/popper*"));

            // Custom Styles
            bundles.Add(new StyleBundle("~/Content/CustomStyle")
                .Include("~/Content/style.css"));
        }
    }
}