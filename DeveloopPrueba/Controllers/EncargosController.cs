using AutoMapper;
using DeveloopPrueba.Helpers;
using DeveloopPrueba.Models;
using DeveloopPrueba.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        public IHttpActionResult UploadFile(int rowIndex = 0)
        {
            if(rowIndex < 0)
            {
                return BadRequest("El índice de la fila no puede ser menor que cero.");
            }

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
                for(int i = rowIndex; i < data.Tables[0].Rows.Count; i++)
                {
                    DataRow row = data.Tables[0].Rows[i];

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

            // Se efectua las validaciones de cada uno de las propiedades para devolverlas al frontend.
            ICollection<ValidacionEncargoModelDTO> encargosValidados = new List<ValidacionEncargoModelDTO>();
            foreach(EncargoModelDTO encargo in encargosXls)
            {
                encargosValidados.Add(ValidationHelper.ObtenerValidaciones(encargo));
            }

            // Se retorna toda la información al frontend.
            return Ok(new { Encargos = encargosValidados });
        }

        ////////////////////////
        /// CRUD DE ENCARGOS ///
        ////////////////////////

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> CreateEncargo(EncargoModelDTO encargoDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EncargoModel encargoContext = Mapper.Map<EncargoModel>(encargoDTO);
            DbContext.Encargos.Add(encargoContext);
            await DbContext.SaveChangesAsync();

            encargoDTO = Mapper.Map<EncargoModelDTO>(encargoContext);

            return Created("api/Encargos/" + encargoDTO.EncargoId, encargoDTO);
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateEncargo(EncargoModelDTO encargoDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EncargoModel encargoContext = Mapper.Map<EncargoModel>(encargoDTO);
            DbContext.Entry(encargoContext).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();

            encargoDTO = Mapper.Map<EncargoModelDTO>(encargoContext);

            return Ok(encargoDTO);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> DeleteEncargo(int id)
        {
            EncargoModel encargoContext = await DbContext.Encargos.FindAsync(id);
            if(encargoContext == null)
            {
                return BadRequest("El id especificado no existe.");
            }

            DbContext.Encargos.Remove(encargoContext);
            await DbContext.SaveChangesAsync();

            EncargoModelDTO encargoDTO = Mapper.Map<EncargoModelDTO>(encargoContext);

            return Ok(encargoDTO);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetEncargoById(int id)
        {
            EncargoModel encargoContext = await DbContext.Encargos.FindAsync(id);
            if (encargoContext == null)
            {
                return BadRequest("El id especificado no existe.");
            }

            EncargoModelDTO encargoDTO = Mapper.Map<EncargoModelDTO>(encargoContext);

            return Ok(encargoDTO);
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetEncargos(int page = 0, int size = 0)
        {
            if(page < 0 || size < 0)
            {
                return BadRequest("Los índices de paginación no pueden ser menores que cero.");
            }

            IQueryable<EncargoModel> encargos = page == 0 || size == 0 
                ? DbContext.Encargos.AsQueryable()
                : DbContext.Encargos
                    .OrderBy(e => e.EncargoId)
                    .Skip((page - 1) * size)
                    .Take(size);

            ICollection<EncargoModelDTO> encargosDTO = Mapper.Map<List<EncargoModelDTO>>(encargos.ToList());

            return Ok(new { Encargos = encargosDTO });
        }
    }
}
