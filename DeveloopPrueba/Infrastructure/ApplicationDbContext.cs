using DeveloopPrueba.Models;
using DeveloopPrueba.Models.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeveloopPrueba.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=DeveloopSoftwareDB")
        {

        }

        public virtual DbSet<EncargoModel> Encargos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Se agrega la configuración de EncargoModel.
            modelBuilder.Configurations.Add(new EncargoModelConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}