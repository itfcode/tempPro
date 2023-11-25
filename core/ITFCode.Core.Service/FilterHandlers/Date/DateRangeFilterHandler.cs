using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers.Base;
using System.Linq.Expressions;

namespace ITFCode.Core.Service.FilterHandlers
{
    public class DateRangeFilterHandler : FilterHandler<DateRangeFilter>
    {
        #region Constructors

        public DateRangeFilterHandler(DateRangeFilter filter) : base(filter) { }

        #endregion

        #region Public Methods 

        public override Expression<Func<TEntity, bool>> Handle<TEntity>()
        {
            var item = Expression.Parameter(typeof(TEntity), "item");

            var property = GetProperty(item, Filter.PropertyName);

            var startDate = Filter.From;
            var finishDate = Filter.To;

            var valueFrom = GetValue(startDate, property.Type);
            var valueTo = GetValue(finishDate, property.Type);

            var conditionFrom = Expression.GreaterThanOrEqual(property, valueFrom);
            var conditionTo = Expression.LessThanOrEqual(property, valueTo);
            var conditionFromAndTo = Expression.AndAlso(conditionFrom, conditionTo);

            return Expression.Lambda<Func<TEntity, bool>>(conditionFromAndTo, item);
        }

        #endregion
    }
}