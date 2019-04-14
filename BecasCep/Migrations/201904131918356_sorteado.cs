namespace BecasCep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sorteado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personas", "Sorteado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personas", "Sorteado");
        }
    }
}
