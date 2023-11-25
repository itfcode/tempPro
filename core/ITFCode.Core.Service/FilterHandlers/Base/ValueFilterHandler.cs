using ITFCode.Core.DTO.FilterOptions.Base;
using System.Linq.Expressions;

namespace ITFCode.Core.Service.FilterHandlers.Base
{
    public abstract class ValueFilterHandler<TFilter> : FilterHandler<TFilter>
        where TFilter : FilterOption
    {
        #region Constructions

        public ValueFilterHandler(TFilter filter) : base(filter) { }

        #endregion

        #region Public Methods 

        protected Expression<Func<TEntity, bool>> HandleValue<TEntity, TValue>()
        {
            var itemExpr = Expression.Parameter(typeof(TEntity), "item");
            var propertyExpr = GetProperty(itemExpr, Filter.PropertyName);

            var filterOption = (Filter as FilterValueOption<TValue>)
                ?? throw new NullReferenceException($"Filter value cannot be defined");

            var valueExpr = GetValue(filterOption.Value, propertyExpr.Type);

            return Expression.Lambda<Func<TEntity, bool>>(Expression.Equal(propertyExpr, valueExpr), itemExpr);
        }

        #endregion
    }
}