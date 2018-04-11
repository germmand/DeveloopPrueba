using DeveloopPrueba.Models.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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

            // Lista donde se almacenarán los datos del fichero.
            ICollection<EncargoModelDTO> encargosXls = new List<EncargoModelDTO>();

            // Se obtiene el archivo y se guarda en la carpeta Temporary.
            HttpPostedFile postedFile = httpRequest.Files[0];
            string fileExtension = postedFile.FileName.Split('.').Last();
            string filePath = HttpContext.Current.Server.MapPath("~/Temporary/" + Guid.NewGuid().ToString("n") + "." + fileExtension);
            postedFile.SaveAs(filePath);

            // Se procede a leer la información en el fichero.
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=Excel 8.0";
            OleDbConnection xlsConnection = new OleDbConnection(connectionString);     
            try
            {
                xlsConnection.Open();
                // Ésto se hace con la intención de hacer la lectura de páginas general.
                // Siempre se leerá la primera página independientemente del nombre que ésta tenga asignada.
                DataTable sheets = xlsConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = sheets.Rows[0]["TABLE_NAME"].ToString();

                // Se crea la query para la lectura completa del archivo.
                OleDbCommand command = new OleDbCommand(String.Format("SELECT * FROM [{0}]", sheetName), xlsConnection);
                OleDbDataAdapter adapter = new OleDbDataAdapter()
                {
                    SelectCommand = command
                };

                // Se llena un DataSet con la información del fichero.
                DataSet data = new DataSet();
                adapter.Fill(data);

                // Se llena la colleción con la información en el fichero.
                foreach(DataRow row in data.Tables[0].Rows)
                {
                    DateTime? date = row["Fecha"] as DateTime?;
                    // Se convierte la fecha a cadena; dado un formato inválido, stringData tomará un valor nulo.
                    string stringDate = date != null ? 
                        ((DateTime)date).ToString("dd/MM/yyyy hh:mm", System.Globalization.CultureInfo.InvariantCulture) 
                        : null;

                    encargosXls.Add(new EncargoModelDTO()
                    {
                        EncargoId       = 0,
                        Albaran         = row["albaran"]        as string,
                        Destinatario    = row["destinatario"]   as string,
                        Direccion       = row["direccion"]      as string,
                        Poblacion       = row["poblacion"]      as string,
                        CP              = row["cp"]             as string,
                        Provincia       = row["provincia"]      as string,
                        Telefono        = row["telefono"]       as string,
                        Observaciones   = row["observaciones"]  as string,
                        Fecha           = stringDate
                    });
                }
            } catch(Exception ex)
            {
                File.Delete(filePath);
                return BadRequest("Error intentando leer el fichero: " + ex.ToString());
            } finally
            {
                xlsConnection.Close();
            }

            // Se elimina el archivo del a carpeta Temporary.
            File.Delete(filePath);

            // Se retorna toda la información al frontend.
            return Ok(new { Encargos = encargosXls });
        }
    }
}
