using ITFCode.Core.Domain.Entities.Base.Interface;
using System.Linq.Expressions;

namespace ITFCode.Core.Domain.Repositories.Interfaces
{
    public interface IEntityRepository<TEntity>  
        where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetEntities();
        IQueryable<TEntity> GetAll();

        #region Non-Async

        TEntity? Get(object key, params object[] keys);
        TEntity? Find(Expression<Func<TEntity, bool>> filter);
        bool Exists(Expression<Func<TEntity, bool>>? filter = null);
        int Count(Expression<Func<TEntity, bool>>? filter = null);
        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        // void Delete(object id);
        // void Delete(TEntity entityToDelete);
        // Task DeleteAsync(object id);

        // IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, int skip = -1, int take = -1, string includeProperties = "");
        // Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, int skip = -1, int take = -1, string includeProperties = "");

        //void Update(object[] keyValues, Action<TEntity> updater);
        //void UpdateRange(IEnumerable<object[]> keys, Action<TEntity> updater);

        //void Delete(object[] keys);
        //void DeleteRange(object[] keys);

        #endregion

        #region Async 

        Task<TEntity?> GetAsync(object key, params object[] keys);
        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>>? filter = null, CancellationToken cancellationToken = default);
        Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null, CancellationToken cancellationToken = default);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        //Task UpdateAsync(object[] keyValues, Action<TEntity> updater, CancellationToken cancellationToken = default);
        //Task UpdateRangeAsync(IEnumerable<object[]> keys, Action<TEntity> updater, CancellationToken cancellationToken = default);

        //Task DeleteAsync(object[] keys, CancellationToken cancellationToken = default);
        //Task DeleteRangeAsync(object[] keys, CancellationToken cancellationToken = default);

        #endregion
    }
}