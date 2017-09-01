using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace Models
{
    public class SistemaDeRestauranteContext : DbContext
    {
        public SistemaDeRestauranteContext(DbContextOptions<SistemaDeRestauranteContext> options)
            : base(options)
        { }

        public DbSet<Restaurante> Restaurantes { get; set; }

        public DbSet<Prato> Pratos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
