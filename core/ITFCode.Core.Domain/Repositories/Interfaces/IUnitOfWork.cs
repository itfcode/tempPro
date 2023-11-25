namespace ITFCode.Core.Domain.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        #region Non-Async

        int Commit();
        void Rollback();

        #endregion

        #region Async

        Task<int> CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);

        #endregion
    }
}