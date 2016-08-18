using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ExamenMVCAjax.Models
{
    public class ApplicationDbContext : DbContext//IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection"/*, throwIfV1Schema: false*/)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Factura> Factura { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FacturaMap());

        }

        public class FacturaMap : EntityTypeConfiguration<Factura>
        {
            public FacturaMap()
            {
                HasMany(f => f.Productos)
                    .WithMany(p => p.Facturas)
                    .Map(fp =>
                    {
                        fp.MapLeftKey("FacturaId");
                        fp.MapRightKey("ProductoId");
                        fp.ToTable("FacturasProductos");
                    });
            }
        }


    }
}