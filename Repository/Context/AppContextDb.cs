using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class AppContextDb : DbContext
    {

       public AppContextDb(DbContextOptions<AppContextDb> options) : base(options)
       {

       }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Elemento> Elementos {  get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalle> PedidoDetalles { get; set; }
        public DbSet<Remito> Remitos { get; set; }
        public DbSet<RemitoDetalle> RemitoDetalles { get; set; }
        public DbSet<User> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>().HasKey(p => p.IdPedido);

            modelBuilder.Entity<Pedido>().ToTable("Pedidos");
            modelBuilder.Entity<PedidoDetalle>().ToTable("DetallePedido");
            modelBuilder.Entity<RemitoDetalle>().ToTable("DetalleRemito");
            modelBuilder.Entity<User>().ToTable("Usuarios");

            modelBuilder.Entity<Pedido>()
                .HasMany(p => p.Detalles)
                .WithOne()
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Remito>()
                .HasMany(r => r.Detalles)
                .WithOne()
                .HasForeignKey(r => r.RemitoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
