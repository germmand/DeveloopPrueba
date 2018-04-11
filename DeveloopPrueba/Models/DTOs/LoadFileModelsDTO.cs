using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloopPrueba.Models.DTOs
{
    public class ErrorEncargoModelDTO
    {
        public string PropertyName { get; set; }
        public string ErrorDescription { get; set; }
    }

    public class ValidacionEncargoModelDTO
    {
        public EncargoModelDTO Encargo { get; set; }
        public ICollection<ErrorEncargoModelDTO> ValidationErrors { get; set; }
    }
}