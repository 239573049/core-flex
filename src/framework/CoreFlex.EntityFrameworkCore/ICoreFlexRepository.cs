using System.Linq.Expressions;
using Masa.BuildingBlocks.Ddd.Domain.Entities;
using Masa.BuildingBlocks.Ddd.Domain.Repositories;

namespace CoreFlex.EntityFrameworkCore;

public interface ICoreFlexRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : IComparable
{
    /// <summary>
    /// 判断是否存在
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    /// <summary>
    /// 更新指定字段
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="properties"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateSpecifiedField(TEntity entity, Expression<Func<TEntity, object>>[] properties,
        CancellationToken cancellationToken = default);
}