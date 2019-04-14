namespace BecasCep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Carrera : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carreras",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Sede = c.String(),
                        Turno = c.String(),
                        Nombre = c.String(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaEdicion = c.DateTime(nullable: false),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Personas", "Carrera_Id", c => c.Guid());
            CreateIndex("dbo.Personas", "Carrera_Id");
            AddForeignKey("dbo.Personas", "Carrera_Id", "dbo.Carreras", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personas", "Carrera_Id", "dbo.Carreras");
            DropIndex("dbo.Personas", new[] { "Carrera_Id" });
            DropColumn("dbo.Personas", "Carrera_Id");
            DropTable("dbo.Carreras");
        }
    }
}
