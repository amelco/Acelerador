using Acelerador.Entities;
using Microsoft.EntityFrameworkCore;

namespace Acelerador.DbContexts.Interfaces
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : EntidadeBase;
        Task<int> SaveChangesAsync();
    }
}
