namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _210701Emisor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emisors", "urlFel", c => c.String());
            AddColumn("dbo.Emisors", "entorno", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Emisors", "entorno");
            DropColumn("dbo.Emisors", "urlFel");
        }
    }
}
