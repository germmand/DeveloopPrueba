using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeveloopPrueba.Models.DTOs
{
    public class EncargoModelDTO
    {
        [Required(ErrorMessage = "El campo ID es obligatorio.")]
        public int EncargoId { get; set; }

        [Required(ErrorMessage = "El campo Albarán es obligatorio.")]
        [StringLength(10, ErrorMessage = "La longitud máxima de Albarán es de 10 caracteres.")]
        public string Albaran { get; set; }

        [Required(ErrorMessage = "El campo Destinatario es obligatorio.")]
        [StringLength(28, ErrorMessage = "La longitud máxima de Destinatario es de 28 caracteres.")]
        public string Destinatario { get; set; }

        [Required(ErrorMessage = "El campo Dirección es obligatorio.")]
        [StringLength(250, ErrorMessage = "La longitud máxima de Dirección es de 250 caracteres.")]
        public string Direccion { get; set; }

        [StringLength(10, ErrorMessage = "La longitud máxima de Población es de 10 caracteres.")]
        public string Poblacion { get; set; }

        [Required(ErrorMessage = "El campo CP es obligatorio.")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "La longitud requerida para el campo CP es de 5 caracteres.")]
        public string CP { get; set; }

        [Required(ErrorMessage = "El campo Provincia es obligatorio.")]
        [StringLength(20, ErrorMessage = "La longitud máxima de Provincia es de 20 caracteres.")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        [StringLength(10, ErrorMessage = "La longitud máxima de Teléfono es de 10 caracteres.")]
        public string Telefono { get; set; }

        [StringLength(500, ErrorMessage = "La longitud máxima de Observaciones es de 500 caracteres.")]
        public string Observaciones { get; set; }

        [Required(ErrorMessage = "El campo Fecha es obligatorio.")]
        public string Fecha { get; set; }
    }
}