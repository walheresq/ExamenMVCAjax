namespace ExamenMVCAjax.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetableFacturas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FacturaProductoes", "Factura_Id", "dbo.Facturas");
            DropForeignKey("dbo.Productoes", "FacturaProducto_FacturaId", "dbo.FacturaProductoes");
            DropIndex("dbo.FacturaProductoes", new[] { "Factura_Id" });
            DropIndex("dbo.Productoes", new[] { "FacturaProducto_FacturaId" });
            AddColumn("dbo.Facturas", "Total", c => c.Double(nullable: false));
            AddColumn("dbo.Facturas", "SubTotal", c => c.Double(nullable: false));
            AddColumn("dbo.Facturas", "Impuesto", c => c.Double(nullable: false));
            DropColumn("dbo.Productoes", "FacturaProducto_FacturaId");
            DropTable("dbo.FacturaProductoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FacturaProductoes",
                c => new
                    {
                        FacturaId = c.Int(nullable: false, identity: true),
                        Factura_Id = c.Int(),
                    })
                .PrimaryKey(t => t.FacturaId);
            
            AddColumn("dbo.Productoes", "FacturaProducto_FacturaId", c => c.Int());
            DropColumn("dbo.Facturas", "Impuesto");
            DropColumn("dbo.Facturas", "SubTotal");
            DropColumn("dbo.Facturas", "Total");
            CreateIndex("dbo.Productoes", "FacturaProducto_FacturaId");
            CreateIndex("dbo.FacturaProductoes", "Factura_Id");
            AddForeignKey("dbo.Productoes", "FacturaProducto_FacturaId", "dbo.FacturaProductoes", "FacturaId");
            AddForeignKey("dbo.FacturaProductoes", "Factura_Id", "dbo.Facturas", "Id");
        }
    }
}
