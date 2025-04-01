using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OO.SysProductos.EN;


namespace OO.SysProductos.DAL
{
    public class SysProductosDBContext : DbContext
    {
        public SysProductosDBContext(DbContextOptions<SysProductosDBContext> options) : base(options)
        {

        }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
		public DbSet<Compra> Compras { get; set; }
		public DbSet<DetalleCompra> DetalleCompra { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DetalleCompra>()
	       .HasOne(d => d.Compra)
	       .WithMany(c => c.DetalleCompras)
	       .HasForeignKey(d => d.IdCompra);

			base.OnModelCreating(modelBuilder);
		}
	}
}
