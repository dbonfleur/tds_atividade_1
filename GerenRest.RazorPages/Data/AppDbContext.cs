
using GerenRest.RazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenRest.RazorPages.Data {
    public class AppDbContext : DbContext
    {
        public DbSet<MesaModel>? MesaModel;
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=tds.db;Cache=Shared");

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
        }
    }
}  