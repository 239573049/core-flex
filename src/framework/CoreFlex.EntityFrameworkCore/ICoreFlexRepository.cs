using System.Linq.Expressions;
using Masa.BuildingBlocks.Ddd.Domain.Entities;
using Masa.BuildingBlocks.Ddd.Domain.Repositories;

namespace CoreFlex.EntityFrameworkCore;

public interface ICoreFlexRepository<TEntity> where TEntity : class, IEntity, IRepository<IEntity>
{
    /// <summary>
    /// 判断是否存在
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}