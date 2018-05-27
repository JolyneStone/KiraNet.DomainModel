using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KiraNet.DomainModel
{
    /// <summary>
    /// 聚集的操作应由具体的仓储接口定义，对聚集实体的操作都通过该仓储接口调用
    /// </summary>
    public interface IRepository<TEntity> : IAggregateRoot
        where TEntity : class, IEntity
    {
        IIncludableQueryable<TEntity, TProperty> Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationPropertyPath);
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        void Insert(TEntity entity);
        Task InsertAsync(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        Task InsertRangeAsync(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entity);
        void Attach(TEntity entity);
        void AttachRange(IEnumerable<TEntity> entity);
        Task<int> CountAsync();
        int Count();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        int Count(Expression<Func<TEntity, bool>> predicate);
        bool IsExist(Expression<Func<TEntity, bool>> predicate);
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate);
        bool IsAll(Expression<Func<TEntity, bool>> predicate);
        Task<bool> IsAllAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
