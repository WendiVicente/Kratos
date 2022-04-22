namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Configurations : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pedidoes", "NoDocPedido");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedidoes", "NoDocPedido", c => c.String());
        }
    }
}
