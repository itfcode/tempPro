using ITFCode.Core.Domain.Exceptions;
using ITFCode.Core.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ITFCode.Core.Domain.Repositories
{
    public abstract class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        #region Private & Protected Fields 

        private readonly TDbContext _dbContext;
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        //private readonly IRepositoryFactory _repositoryFactory;

        #endregion

        #region Protected Properties 

        protected TDbContext Context => _dbContext ?? throw new NullReferenceException($"DbContext is null");
        protected ILogger Logger => _logger ?? throw new NullReferenceException("Logger Service not defined");
        protected IServiceProvider ServiceProvider => _serviceProvider ?? throw new NullReferenceException("Service Provider not defined");
        //protected IRepositoryFactory RepositoryFactory => _repositoryFactory ?? throw new NullReferenceException("Repository Factory not defined");

        #endregion

        #region Constructors 

        public UnitOfWork(TDbContext dbContext, IServiceProvider serviceProvider, ILogger<UnitOfWork<TDbContext>> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            //_repositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(repositoryFactory));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #endregion

        #region IUnitOfWorkCore Implementation : Non-Async

        public int Commit()
        {
            return 1;
        }

        public void Rollback()
        {
        }

        #endregion

        #region IUnitOfWorkCore Implementation : Async

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
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

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            var entries = Context.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged);

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        await entry.ReloadAsync(cancellationToken);
                        break;
                }
            }
        }

        #endregion

        #region Protected Methods 

        protected T ResolveRepository<T>() where T : class
        {
            try
            {
                return (T)ServiceProvider.GetService(typeof(T))
                    ?? throw new NullReferenceException($"Provider cannot define the service '{typeof(T)}'");
            }
            catch (Exception ex)
            {
                throw new RepositoryResolvingException(
                    message: $"Exception on resolving type of {typeof(T).FullName}",
                    innerException: ex);
            }
        }

        #endregion
    }
}