namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210701EmisorWithUrlToken : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emisors", "urlToken", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Emisors", "urlToken");
        }
    }
}
