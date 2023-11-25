using ITFCode.Core.DTO.Models.Base.Interfaces;

namespace ITFCode.Core.Service.Data.Interfaces
{
    public interface IReadWriteDataService<TEntityDTO> :  IReadDataService<TEntityDTO>
        where TEntityDTO : class, IEntityDTO
    {
    }
}
