using ITFCode.Core.Domain.Entities.Base.Interface;
using ITFCode.Core.Domain.Entities.Base.Interfaces;
using ITFCode.Core.Domain.Exceptions;
using ITFCode.Core.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace ITFCode.Core.Domain.Repositories
{
    public abstract class EntityRepository<TContext, TEntity> : IEntityRepository<TEntity>
        where TContext : DbContext
        where TEntity : class, IEntity
    {
        #region Private & Protceted Fields

        private readonly TContext _context;

        #endregion

        #region Protected Properties

        protected TContext Context => _context ?? throw new Exception();

        protected DbSet<TEntity> DbSet => Context.Set<TEntity>();

        #endregion

        #region Constructors 

        public EntityRepository([NotNull] TContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion

        #region IEntityRepository Implementation : Common

        public IQueryable<TEntity> GetEntities() => GetQueryable();
        public IQueryable<TEntity> GetAll() => GetQueryable();

        #endregion

        #region IEntityRepository Implementation : Non-Async

        public virtual TEntity Get(object key, params object[] keys)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            object[] keyValues = (new object[] { key }).Union(keys).ToArray();

            var entity = DbSet.Find(keyValues);

            if (entity != null)
                return DetachEntity(entity);
            else
                throw new EntityNotFoundException(keyValues, typeof(TEntity));
        }

        public virtual TEntity? Find(Expression<Func<TEntity, bool>> filter)
            => filter is not null
                ? DbSet.AsNoTracking().FirstOrDefault(filter)
                : throw new ArgumentNullException(nameof(filter));

        public virtual bool Exists(Expression<Func<TEntity, bool>>? filter = null)
            => filter is null ? DbSet.Any() : DbSet.Any(filter);

        public virtual int Count(Expression<Func<TEntity, bool>>? filter = null)
            => filter is null ? DbSet.Count() : DbSet.Count(filter);

        public virtual TEntity Add(TEntity entity)
            => entity is not null
            ? DbSet.Add(entity).Entity
            : throw new ArgumentNullException(nameof(entity));

        public virtual void AddRange(IEnumerable<TEntity> entities)
            => DbSet.AddRange(entities ?? throw new ArgumentNullException(nameof(entities)));

        #endregion

        #region IEntityRepository Implementation : Async

        public virtual async Task<TEntity?> GetAsync(object key, params object[] keys)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            object[] keyValues = (new object[] { key }).Union(keys).ToArray();

            var entity = DbSet.Find(keyValues);

            if (entity != null)
                return DetachEntity(entity);
            else
                throw new EntityNotFoundException(keyValues, typeof(TEntity));
        }

        public virtual async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
            => filter is not null
            ? await DbSet.AsNoTracking().FirstOrDefaultAsync(filter, cancellationToken)
            : throw new ArgumentNullException(nameof(filter));

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>>? filter = null, CancellationToken cancellationToken = default)
            => filter is null
            ? await DbSet.AnyAsync(cancellationToken)
            : await DbSet.AnyAsync(filter, cancellationToken);

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null, CancellationToken cancellationToken = default)
            => filter is null
            ? await DbSet.CountAsync(cancellationToken)
            : await DbSet.CountAsync(filter, cancellationToken);

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
            => (await DbSet.AddAsync(entity ?? throw new ArgumentNullException(nameof(entity)), cancellationToken)).Entity;

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
            => await DbSet.AddRangeAsync(entities ?? throw new ArgumentNullException(nameof(entities)), cancellationToken);

        #endregion

        #region Private & Protected Methods 

        protected virtual IQueryable<TEntity> GetQueryable() => DbSet.AsQueryable();

        protected virtual void ValidateParam<TParam>(TParam param, string paramName)
        {
            ArgumentNullException.ThrowIfNull(param, paramName);
        }

        public virtual async Task<int> CommitChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await Context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new EntityCommitingException(ex);
            }
        }

        protected TEntity AttachEntity(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
                DbSet.Attach(entity);

            return entity;
        }

        protected void Update(TEntity entity)
        {
            try
            {
                if (entity is ITrackable trackable)
                    trackable.ModifiedAt = DateTime.Now;

                DbSet.Update(AttachEntity(entity));
            }
            catch (Exception ex)
            {
                throw new EntityUpdatingException(ex);
            }
        }

        protected void UpdateRange(IEnumerable<TEntity> entities)
        {
            try
            {
                DbSet.UpdateRange(AttachEntities(entities));
            }
            catch (Exception ex)
            {
                throw new EntityRangeUpdatingException(ex);
            }
        }

        protected IEnumerable<TEntity> AttachEntities(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                    DbSet.Attach(entity);
            }

            return entities;
        }

        protected TEntity DetachEntity(TEntity entity)
        {
            if (Context.Entry(entity).State != EntityState.Detached)
                Context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        #endregion
    }
}