using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeveloopPrueba.Models
{
    public class EncargoModel
    {
        public int EncargoId { get; set; }
        public string Albaran { get; set; }
        public string Destinatario { get; set; }
        public string Direccion { get; set; }
        public string Poblacion { get; set; }
        // La explicación del porqué de éste atributo acá está comentado en la configuración del modelo en el archivo:
        // EncargoModelConfiguration.cs
        [MinLength(5)]
        public string CP { get; set; }
        public string Provincia { get; set; }
        public string Telefono { get; set; }
        public string Observaciones { get; set; }
        public DateTime Fecha { get; set; }
    }
}