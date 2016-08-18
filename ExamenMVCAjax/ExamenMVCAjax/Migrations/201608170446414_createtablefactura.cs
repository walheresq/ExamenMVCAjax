namespace ExamenMVCAjax.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtablefactura : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaCreacion = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            AddColumn("dbo.Productoes", "Factura_Id", c => c.Int());
            CreateIndex("dbo.Productoes", "Factura_Id");
            AddForeignKey("dbo.Productoes", "Factura_Id", "dbo.Facturas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productoes", "Factura_Id", "dbo.Facturas");
            DropForeignKey("dbo.Facturas", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Productoes", new[] { "Factura_Id" });
            DropIndex("dbo.Facturas", new[] { "ClienteId" });
            DropColumn("dbo.Productoes", "Factura_Id");
            DropTable("dbo.Facturas");
        }
    }
}
