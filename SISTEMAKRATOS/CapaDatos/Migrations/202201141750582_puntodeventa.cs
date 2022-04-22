namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class puntodeventa : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.DetalleCotizacions", name: "DetalleTomoEdicionId", newName: "DetalleTomoEdicion_Id");
            RenameColumn(table: "dbo.DetalleFacturas", name: "DetalleTomoEdicionId", newName: "DetalleTomoEdicion_Id");
            RenameColumn(table: "dbo.DetalleVales", name: "DetalleTomoEdicionId", newName: "DetalleTomoEdicion_Id");
            RenameColumn(table: "dbo.SolicitudDetalles", name: "DetalleTomoEdicionId", newName: "DetalleTomoEdicion_Id");
            RenameIndex(table: "dbo.DetalleCotizacions", name: "IX_DetalleTomoEdicionId", newName: "IX_DetalleTomoEdicion_Id");
            RenameIndex(table: "dbo.DetalleFacturas", name: "IX_DetalleTomoEdicionId", newName: "IX_DetalleTomoEdicion_Id");
            RenameIndex(table: "dbo.DetalleVales", name: "IX_DetalleTomoEdicionId", newName: "IX_DetalleTomoEdicion_Id");
            RenameIndex(table: "dbo.SolicitudDetalles", name: "IX_DetalleTomoEdicionId", newName: "IX_DetalleTomoEdicion_Id");
            AddColumn("dbo.DetalleColors", "CodigoGeneral", c => c.String());
            DropColumn("dbo.DetalleCotizacions", "Descuento");
            DropColumn("dbo.DetalleVales", "Descuento");
            DropColumn("dbo.DetalleVales", "PrecioTotal");
            DropColumn("dbo.DocumentoCertificadoSATs", "QRImagen");
            DropTable("dbo.DetallePagoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DetallePagoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacturaId = c.Guid(),
                        CajaId = c.Int(nullable: false),
                        Documento = c.String(),
                        Pago = c.String(),
                        Entidad = c.String(),
                        Numero = c.String(),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DocumentoCertificadoSATs", "QRImagen", c => c.Binary());
            AddColumn("dbo.DetalleVales", "PrecioTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DetalleVales", "Descuento", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DetalleCotizacions", "Descuento", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.DetalleColors", "CodigoGeneral");
            RenameIndex(table: "dbo.SolicitudDetalles", name: "IX_DetalleTomoEdicion_Id", newName: "IX_DetalleTomoEdicionId");
            RenameIndex(table: "dbo.DetalleVales", name: "IX_DetalleTomoEdicion_Id", newName: "IX_DetalleTomoEdicionId");
            RenameIndex(table: "dbo.DetalleFacturas", name: "IX_DetalleTomoEdicion_Id", newName: "IX_DetalleTomoEdicionId");
            RenameIndex(table: "dbo.DetalleCotizacions", name: "IX_DetalleTomoEdicion_Id", newName: "IX_DetalleTomoEdicionId");
            RenameColumn(table: "dbo.SolicitudDetalles", name: "DetalleTomoEdicion_Id", newName: "DetalleTomoEdicionId");
            RenameColumn(table: "dbo.DetalleVales", name: "DetalleTomoEdicion_Id", newName: "DetalleTomoEdicionId");
            RenameColumn(table: "dbo.DetalleFacturas", name: "DetalleTomoEdicion_Id", newName: "DetalleTomoEdicionId");
            RenameColumn(table: "dbo.DetalleCotizacions", name: "DetalleTomoEdicion_Id", newName: "DetalleTomoEdicionId");
        }
    }
}
