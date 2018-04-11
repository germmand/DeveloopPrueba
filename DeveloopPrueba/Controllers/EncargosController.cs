using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DeveloopPrueba.Controllers
{
    [RoutePrefix("api/Encargos")]
    public class EncargosController : BaseApiController
    {
        public EncargosController()
        {

        }

        [HttpPost]
        [Route("UploadFile")]
        public IHttpActionResult UploadFile()
        {
            HttpRequest httpRequest = HttpContext.Current.Request;
            if(httpRequest.Files.Count <= 0)
            {
                return BadRequest("No se ha enviado ningún archivo.");
            }

            // Se obtiene el archivo y se guarda en la carpeta Temporary.
            HttpPostedFile postedFile = httpRequest.Files[0];
            string fileExtension = postedFile.FileName.Split('.').Last();
            string filePath = HttpContext.Current.Server.MapPath("~/Temporary/" + Guid.NewGuid().ToString("n") + "." + fileExtension);
            postedFile.SaveAs(filePath);

            // Se elimina el archivo del a carpeta Temporary.
            File.Delete(filePath);

            // Se retorna toda la información al frontend.
            return Ok();
        }
    }
}
