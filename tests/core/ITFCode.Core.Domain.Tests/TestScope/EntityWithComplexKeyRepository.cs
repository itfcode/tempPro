using ITFCode.Core.Domain.Repositories;

namespace ITFCode.Core.Domain.Tests.TestScope
{
    public class EntityWithComplexKeyRepository : EntityRepository<TestDbContext, EntityWithComplexKey>, IEntityWithComplexKeyRepository
    {
        public EntityWithComplexKeyRepository(TestDbContext context) : base(context)
        {
        }
    }
}
