namespace ITFCode.Core.DTO.Models.Base.Interfaces
{
    public interface IEntityDTO
    {
    }

    public interface IEntityDTO<TKey> : IEntityDTO where TKey : IComparable
    {
        public TKey Id { get; set; }
    }
}