using ITFCode.Core.Domain.Entities.Base;

namespace ITFCode.Core.Domain.Tests.TestScope
{
    public class EntityWithComplexKey : Entity
    {
        public int Key1 { set; get; }

        public int Key2 { set; get; }

        public required string Name { set; get; }
    }
}
