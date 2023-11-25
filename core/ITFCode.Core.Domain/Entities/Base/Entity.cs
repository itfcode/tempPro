using ITFCode.Core.Domain.Entities.Base.Interface;

namespace ITFCode.Core.Domain.Entities.Base
{
    public abstract class Entity : IEntity
    {
    }

    public abstract class Entity<TKey> : IEntity<TKey> where TKey : IComparable
    {
        public virtual required TKey Id { get; set; }
    }
}