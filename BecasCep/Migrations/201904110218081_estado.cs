namespace BecasCep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class estado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personas", "Estado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personas", "Estado");
        }
    }
}
