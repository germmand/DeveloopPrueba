using System;
using System.Threading.Tasks;
using DeveloopPrueba.Infrastructure;
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
            // Se crea una instancia de ApplicationDbContext por petición en el pipeline de Owin.
            app.CreatePerOwinContext(ApplicationDbContext.Create);

            // Habilitando CORS para el Middleware.
            app.UseCors(CorsOptions.AllowAll);
        }
    }
}
