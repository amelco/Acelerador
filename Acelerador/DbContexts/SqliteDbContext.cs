using Acelerador.DbContexts.Interfaces;
using Acelerador.Entities;
using Microsoft.EntityFrameworkCore;

namespace Acelerador.DbContexts
{
    public class SqliteDbContext : DbContext, IDbContext
    {
        public SqliteDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING") ??
                $@"Data Source={Directory.GetCurrentDirectory()}\{Environment.GetEnvironmentVariable("SQL_DATABASE_NAME")}");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Adicionar entidades aqui
            builder.Entity<Cliente>();
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : EntidadeBase
        {
            return base.Set<TEntity>();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
