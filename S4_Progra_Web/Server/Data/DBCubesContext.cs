using Microsoft.EntityFrameworkCore;
using S4_Progra_Web.Shared.Modelos;

namespace S4_Progra_Web.Server.Data
{
    public class DBCubesContext : DbContext
    {
        public DBCubesContext(DbContextOptions<DBCubesContext> options) : base(options) { }
        public DbSet<Cube> Cubes { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<CubePedidos> CubePedidos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CubePedidos>()
                .HasKey(c => new { c.CubeId, c.PedidosId });
        }
    }
}
