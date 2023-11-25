using AutoMapper.Internal;
using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.DTO.FilterOptions.Base;
using ITFCode.Core.Service.FilterHandlers.Base;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;

namespace ITFCode.Core.Service.FilterHandlers
{
    public class DateListFilterHandler : ListFilterHandler<DateListFilter>
    {
        #region Private Fields

        #endregion

        #region Constructions

        public DateListFilterHandler(DateListFilter filter) : base(filter) { }

        #endregion

        #region Public Methods 

        public override Expression<Func<TEntity, bool>> Handle<TEntity>()
        {
            var property = typeof(TEntity).GetProperties()
                    .FirstOrDefault(x => x.IsPublic() && x.Name == Filter.PropertyName)
                ?? throw new ArgumentNullException($"Public property '{Filter.PropertyName}' not defined in type '{typeof(TEntity).Name}'");

            if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                return HandleList<TEntity, DateTime>();

            if (property.PropertyType == typeof(DateTimeOffset) || property.PropertyType == typeof(DateTimeOffset?))
                return HandleList<TEntity, DateTimeOffset>();

            throw new ArgumentOutOfRangeException("Type not defined!!!");
        }

        #endregion

        #region Protected methods 

        //protected override List<TVa> GetFilterValues<DateTime>(Type type)
        //{
        //    if (type == null)
        //        throw new ArgumentNullException(nameof(type));

        //    if (type == typeof(DateTime) || type == typeof(DateTime?))
        //        return Filter.Values.;

        //}

        //protected override List<TValue> GetFilterValues<TValue>()
        //{
        //    var type = typeof(TValue);

        //    if (type == typeof(DateTime) || type == typeof(DateTime?))
        //        return Filter.Values.Select(x => x.DateTime).ToList();

        //    return base.GetFilterValues<DateTimeOffset>();
        //}

        #endregion
    }
}