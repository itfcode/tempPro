using ITFCode.Core.Domain.Repositories;

namespace ITFCode.Core.Domain.Tests.TestScope
{
    public class EntityWithSimpleKeyRepository : EntityRepository<TestDbContext, EntityWithSimpleKey>, IEntityWithSimpleKeyRepository
    {
        public EntityWithSimpleKeyRepository(TestDbContext context) : base(context)
        {
        }
    }
}
