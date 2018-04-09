using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(DeveloopPrueba.Startup))]

namespace DeveloopPrueba
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            // Habilitando CORS para el Middleware.
            app.UseCors(CorsOptions.AllowAll);
        }
    }
}
