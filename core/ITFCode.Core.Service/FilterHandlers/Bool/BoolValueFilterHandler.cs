using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers.Base;
using System.Linq.Expressions;

namespace ITFCode.Core.Service.FilterHandlers
{
    public class BoolValueFilterHandler : ValueFilterHandler<BoolValueFilter>
    {
        #region Constructions

        public BoolValueFilterHandler(BoolValueFilter filter) : base(filter) { }

        #endregion

        #region Public Methods 

        public override Expression<Func<TEntity, bool>> Handle<TEntity>()
        {
            switch (Filter.MatchMode)
            {
                case BoolFilterMatchMode.Equals:
                    return HandleValue<TEntity, bool>();
                default:
                    throw new ArgumentOutOfRangeException($"Rule not defined for '{Filter.MatchMode}'");
            }
        }

        #endregion
    }

}