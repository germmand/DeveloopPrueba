namespace DeveloopPrueba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Encargos_Initial_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EncargoModels",
                c => new
                    {
                        EncargoId = c.Int(nullable: false, identity: true),
                        Albaran = c.String(nullable: false, maxLength: 10),
                        Destinatario = c.String(nullable: false, maxLength: 28),
                        Direccion = c.String(nullable: false, maxLength: 250),
                        Poblacion = c.String(maxLength: 10),
                        CP = c.String(nullable: false, maxLength: 5),
                        Provincia = c.String(nullable: false, maxLength: 20),
                        Telefono = c.String(nullable: false, maxLength: 10),
                        Observaciones = c.String(maxLength: 500),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EncargoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EncargoModels");
        }
    }
}
