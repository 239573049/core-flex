using System.Linq.Expressions;
using Masa.BuildingBlocks.Data;
using Masa.BuildingBlocks.Data.UoW;
using Masa.BuildingBlocks.Ddd.Domain.Entities;
using Masa.Contrib.Ddd.Domain.Repository.EFCore;
using Microsoft.EntityFrameworkCore;

namespace CoreFlex.EntityFrameworkCore;

public class CoreFlexRepository<TDbContext, TEntity, TKey> : Repository<TDbContext, TEntity,TKey>,
    ICoreFlexRepository<TEntity, TKey>
    where TDbContext : DbContext, IMasaDbContext
    where TEntity : class, IEntity<TKey>
    where TKey : IComparable
{
    protected CoreFlexRepository(TDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
    {
    }

    public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return Context.Set<TEntity>().AsNoTracking().AnyAsync(predicate, cancellationToken);
    }

    public Task UpdateSpecifiedField(TEntity entity, Expression<Func<TEntity, object>>[] properties,
        CancellationToken cancellationToken = default)
    {
        Context.Set<TEntity>().Attach(entity);
        foreach (var property in properties)
        {
            Context.Entry(entity).Property(property).IsModified = true;
        }

        Context.Set<TEntity>().Update(entity);
        return Task.CompletedTask;
    }
}