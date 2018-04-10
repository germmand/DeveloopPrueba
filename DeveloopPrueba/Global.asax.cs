using DeveloopPrueba.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using DeveloopPrueba.UtilsConfiguration;

namespace DeveloopPrueba
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Habilitando las optimizaciones de nombre para los bundles.
            BundleTable.EnableOptimizations = true;

            // Se agrega la configuración del AutoMapper.
            AutoMapperConfiguration.Configure();
        }
    }
}
