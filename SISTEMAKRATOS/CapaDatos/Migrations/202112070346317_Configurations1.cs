namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Configurations1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vales", "NoValeDoc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vales", "NoValeDoc", c => c.String());
        }
    }
}
