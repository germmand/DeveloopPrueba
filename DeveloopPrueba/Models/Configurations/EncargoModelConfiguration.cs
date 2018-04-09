using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DeveloopPrueba.Models.Configurations
{
    public class EncargoModelConfiguration : EntityTypeConfiguration<EncargoModel>
    {
        public EncargoModelConfiguration()
        {
            // Se establece la llave primaria.
            HasKey(e => e.EncargoId);

            // Configuración del campo Albarán.
            Property(e => e.Albaran)
                .HasMaxLength(10)
                .IsRequired();

            // Configuración del campo Destinatario.
            Property(e => e.Destinatario)
                .HasMaxLength(28)
                .IsRequired();

            // Configuración del campo Dirección.
            Property(e => e.Direccion)
                .HasMaxLength(250)
                .IsRequired();

            // Configuración del campo Población.
            Property(e => e.Poblacion)
                .HasMaxLength(10);

            // Configuración del campo CP.
            // NOTA: CP tiene que tener de forma obligatoria 5 caracteres.
            // Agregar la longitud mínima es imposible actualmente desde la Fluent API
            // Por lo que se hace a través de una anotación/atributo en el modelo. 
            // La longitud mínima se establece desde el modelo a través de un atributo y la máxima desde la FluentAPI 
            // como se muestra a continuación...
            Property(e => e.CP)
                .HasMaxLength(5)
                .IsRequired();

            // Configuración del campo Provincia.
            Property(e => e.Provincia)
                .HasMaxLength(20)
                .IsRequired();

            // Configuración del campo Teléfono.
            Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsRequired();

            // Configuración del campo Observaciones.
            Property(e => e.Observaciones)
                .HasMaxLength(500);

            // Configuración del campo Fecha.
            Property(e => e.Fecha)
                .IsRequired();
        }
    }
}