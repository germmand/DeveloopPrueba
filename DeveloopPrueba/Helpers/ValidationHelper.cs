using DeveloopPrueba.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeveloopPrueba.Helpers
{
    public static class ValidationHelper
    {
        public static ValidacionEncargoModelDTO ObtenerValidaciones(EncargoModelDTO encargo)
        {
            ValidationContext context = new ValidationContext(encargo, null, null);
            ICollection<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(encargo, context, results, true);

            ValidacionEncargoModelDTO encargoValidado = new ValidacionEncargoModelDTO()
            {
                Encargo = encargo,
                ValidationErrors = new List<ErrorEncargoModelDTO>()
            };

            if (!isValid)
            {
                foreach (ValidationResult result in results)
                {
                    encargoValidado.ValidationErrors.Add(new ErrorEncargoModelDTO()
                    {
                        ErrorDescription = result.ErrorMessage,
                        PropertyName = result.MemberNames.First()
                    });
                }
            }

            return encargoValidado;
        }
    }
}