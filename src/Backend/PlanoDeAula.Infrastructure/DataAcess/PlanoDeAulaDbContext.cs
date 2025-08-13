using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PlanoDeAula.Domain.Entities;

namespace PlanoDeAula.Infrastructure.DataAcess
{
    public class PlanoDeAulaDbContext : DbContext
    {
        public PlanoDeAulaDbContext(DbContextOptions<PlanoDeAulaDbContext> options) : base(options){}

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlanoDeAulaDbContext).Assembly);
        }
    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<PlanoDeAulaDbContext>
    {
        public PlanoDeAulaDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PlanoDeAulaDbContext>();

            builder.UseNpgsql("User ID=oakmauricio;Password=oakmauricio;Host=localhost;Port=5432;Database=oakmauricio;",
                x => x.MigrationsHistoryTable("__ef_historico_migrations"));

            return new PlanoDeAulaDbContext(builder.Options);
        }
    }


}
