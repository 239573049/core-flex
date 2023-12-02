using System.Linq.Expressions;
using Masa.BuildingBlocks.Data;
using Masa.BuildingBlocks.Data.UoW;
using Masa.BuildingBlocks.Ddd.Domain.Entities;
using Masa.BuildingBlocks.Ddd.Domain.Repositories;
using Masa.Contrib.Ddd.Domain.Repository.EFCore;
using Microsoft.EntityFrameworkCore;

namespace CoreFlex.EntityFrameworkCore;

public class CoreFlexRepository<TDbContext, TEntity> : Repository<TDbContext, TEntity>
    where TDbContext : DbContext, IMasaDbContext
    where TEntity : class, IEntity, IRepository<IEntity>
{
    protected CoreFlexRepository(TDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
    {
    }

    public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return Context.Set<TEntity>().AsNoTracking().AnyAsync(predicate, cancellationToken);
    }
}