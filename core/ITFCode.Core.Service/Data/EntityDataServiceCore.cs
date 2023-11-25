using AutoMapper;
using ITFCode.Core.DTO.Models.Base.Interfaces;
using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.Base.Interfaces;
using Microsoft.Extensions.Logging;

namespace ITFCode.Core.Service.Data
{
    public abstract class EntityDataServiceCore<TEntity, TEntityDTO, TUnitOfWork, TRepository> :  DisposableBaseCore, IEntityDataServiceCore<TEntityDTO>
        where TEntity : class, IEntity
        where TEntityDTO : class, IEntityDTO
        where TUnitOfWork : class, IUnitOfWorkCore
        where TRepository : class, IEntityRepositoryCore<TEntity>
    {
        #region Private & Protected Fields 

        private readonly IMapper _mapper;
        private readonly ILogger<EntityDataServiceCore<TEntity, TEntityDTO, TUnitOfWork, TRepository>> _logger;
        private readonly TRepository _repository;
        private readonly TUnitOfWork _unitOfWork;

        #endregion

        #region Protected Properties 

        protected IMapper Mapper => _mapper ?? throw new NullReferenceException("Mapper Service not defined");
        protected ILogger<EntityDataServiceCore<TEntity, TEntityDTO, TUnitOfWork, TRepository>> Logger => _logger ?? throw new NullReferenceException("Logger Service not defined");
        protected TRepository Repository => _repository ?? throw new NullReferenceException("Repository Service not defined");
        protected TUnitOfWork UnitOfWork => _unitOfWork ?? throw new NullReferenceException("UnitOfWork Service not defined");

        #endregion

        #region Constructros 

        protected EntityDataServiceCore(ILogger<EntityDataServiceCore<TEntity, TEntityDTO, TUnitOfWork, TRepository>> logger,
            IMapper mapper,
            TUnitOfWork unitOfWork,
            TRepository repository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion

        #region Public Methods: IEntityDataService Implementation

        public virtual async Task<TEntityDTO> Get(object[] keys, CancellationToken cancellationToken = default)
            => Map(await Repository.Find(keys, cancellationToken));

        public virtual async Task<TEntityDTO> Get(object key, CancellationToken cancellationToken = default)
            => Map(await Repository.Find(key, cancellationToken));

        public Task<IList<TEntityDTO>> GetPage(QueryFilterOptions queryOptions, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Protected Methods 

        protected TEntityDTO Map(TEntity entity) => Mapper.Map<TEntityDTO>(entity);

        protected TEntity Map(TEntityDTO model) => Mapper.Map<TEntity>(model);

        protected TCollection MapRange<TCollection, TCollectionDTO>(TCollectionDTO dtos)
            where TCollection : IEnumerable<TEntity>
            where TCollectionDTO : IEnumerable<TEntityDTO>
        {
            return Mapper.Map<TCollection>(dtos);
        }

        protected TCollectionDTO MapRange<TCollection, TCollectionDTO>(TCollection entities)
            where TCollection : IEnumerable<TEntity>
            where TCollectionDTO : IEnumerable<TEntityDTO>
        {
            return Mapper.Map<TCollectionDTO>(entities);
        }

        #endregion
    }
}