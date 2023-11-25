namespace ITFCode.Core.Domain.Repositories.Interfaces
{
    public interface IRepositoryFactory 
    {
        TRepository GetRepository<TRepository>() where TRepository : class;
    }
}