
using GerenRest.RazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenRest.RazorPages.Data {
    public class AppDbContext : DbContext
    {
        public DbSet<CategoriaModel>? Categorias { get; set; }
        public DbSet<MesaModel>? Mesas { get; set; }
        public DbSet<GarconModel>? Garcons { get; set; }
        public DbSet<ProdutoModel>? Produtos { get; set; }
        public DbSet<AtendimentoModel>? Atendimentos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=tds.db;Cache=Shared");

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<CategoriaModel>().ToTable("Categorias");
            
            modelBuilder.Entity<GarconModel>().ToTable("Garcons");
            
            modelBuilder.Entity<ProdutoModel>().ToTable("Produtos");
            
            modelBuilder.Entity<MesaModel>().ToTable("Eventos");

        }
    }
}  