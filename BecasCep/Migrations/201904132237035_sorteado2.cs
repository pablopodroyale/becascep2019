namespace BecasCep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sorteado2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carreras", "Sede", c => c.Int(nullable: false));
            AlterColumn("dbo.Carreras", "Turno", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carreras", "Turno", c => c.String());
            AlterColumn("dbo.Carreras", "Sede", c => c.String());
        }
    }
}
