using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers.Base;
using System.Linq.Expressions;

namespace ITFCode.Core.Service.FilterHandlers
{
    public class DateValueFilterHandler : FilterHandler<DateValueFilter>
    {
        #region Constructions

        public DateValueFilterHandler(DateValueFilter filter) : base(filter) { }

        #endregion

        #region Public Methods 

        public override Expression<Func<TEntity, bool>> Handle<TEntity>()
        {
            var item = Expression.Parameter(typeof(TEntity), "item");
            var property = GetProperty(item, Filter.PropertyName);

            Expression value;

            if (property.Type == typeof(DateTimeOffset) || property.Type == typeof(DateTimeOffset?))
                value = GetValue(Filter.Value, property.Type);
            else if (property.Type == typeof(DateTime) || property.Type == typeof(DateTime?))
                value = GetValue(Filter.Value.DateTime, property.Type);
            else
                throw new Exception($"Not supported type ('{property.Type.FullName}')");

            Expression body;

            switch (Filter.MatchMode)
            {
                case DateFilterMatchMode.LessThan:
                    body = Expression.LessThan(property, value);
                    break;
                case DateFilterMatchMode.LessThanOrEquals:
                    body = Expression.LessThanOrEqual(property, value);
                    break;
                case DateFilterMatchMode.GreaterThan:
                    body = Expression.GreaterThan(property, value);
                    break;
                case DateFilterMatchMode.GreaterThanOrEquals:
                    body = Expression.GreaterThanOrEqual(property, value);
                    break;
                case DateFilterMatchMode.Equals:
                    body = Expression.Equal(property, value);
                    break;
                default:
                    body = Expression.Equal(property, value);
                    break;
            }

            return Expression.Lambda<Func<TEntity, bool>>(body, item);
        }

        #endregion
    }
}