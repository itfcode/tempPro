using ITFCode.Core.DTO.FilterOptions.Base;
using System.Linq.Expressions;
using System.Reflection;

namespace ITFCode.Core.Service.FilterHandlers.Base
{
    public abstract class ListFilterHandler<TFilter> : FilterHandler<TFilter>
        where TFilter : FilterOption
    {
        #region Protected Properties 

        #endregion

        #region Constructions

        public ListFilterHandler(TFilter filter) : base(filter) { }

        #endregion

        #region Protected Methods 

        protected Expression<Func<TEntity, bool>> HandleList<TEntity, TValue>() where TValue : struct
        {
            var item = Expression.Parameter(typeof(TEntity), "item");
            var value = Expression.Property(item, Filter.PropertyName);

            MethodInfo? methodInfo;
            ConstantExpression list;

            var filterValues = GetFilterValues<TValue>();

            if (filterValues.Count == 0)
                throw new ArgumentException("Filter value collection should be not empty!!!");

            var underlyingType = Nullable.GetUnderlyingType(value.Type);

            bool isNullable = underlyingType != null;

            if (isNullable)
            {
                methodInfo = typeof(List<TValue?>).GetMethod("Contains", new Type[] { typeof(TValue?) });
                var filterValuesExt = filterValues.Select(x => (TValue?)x).ToList();
                list = Expression.Constant(filterValuesExt);
            }
            else
            {
                methodInfo = typeof(List<TValue>).GetMethod("Contains", new Type[] { typeof(TValue) });
                list = Expression.Constant(filterValues);
            }

            if (methodInfo is null)
                throw new NullReferenceException($"Method 'Contains' not defined for type List<{typeof(TValue)}>");

            var body = Expression.Call(list, methodInfo, value);

            return Expression.Lambda<Func<TEntity, bool>>(body, item);
        }

        protected virtual List<TValue> GetFilterValues<TValue>()
        {
            return (Filter as FilterListOption<TValue>)?.Values ?? throw new NullReferenceException("Cannot get list of values");
        }

        protected virtual List<TValue> GetFilterValues<TValue>(Type type)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}