using ITFCode.Core.Domain.Entities.Base;

namespace ITFCode.Core.Domain.Tests.TestScope
{
    public class EntityWithSimpleKey : Entity<int>
    {
        public required string Name { set; get; }
    }
}
