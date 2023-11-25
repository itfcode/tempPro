using ITFCode.Core.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace ITFCode.Core.Domain.Tests.TestScope
{
    public class TestUnitOfWork : UnitOfWork<TestDbContext>, ITestUnitOfWork
    {
        #region Constructors

        public TestUnitOfWork(TestDbContext dbContext, IServiceProvider serviceProvider, ILogger<UnitOfWork<TestDbContext>> logger) : base(dbContext, serviceProvider, logger)
        {
        }

        #endregion
    }
}