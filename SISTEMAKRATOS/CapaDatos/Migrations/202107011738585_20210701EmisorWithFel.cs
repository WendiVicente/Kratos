namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210701EmisorWithFel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emisors", "usernameFel", c => c.String());
            AddColumn("dbo.Emisors", "passwordFel", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Emisors", "passwordFel");
            DropColumn("dbo.Emisors", "usernameFel");
        }
    }
}
