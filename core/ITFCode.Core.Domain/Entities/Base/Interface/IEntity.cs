namespace ITFCode.Core.Domain.Entities.Base.Interface
{
    public interface IEntity
    {
    }

    public interface IEntity<TKey> : IEntity where TKey : IComparable
    {
        TKey Id { get; }
    }
}