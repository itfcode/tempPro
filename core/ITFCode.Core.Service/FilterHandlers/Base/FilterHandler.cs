using AutoMapper.Internal;
using ITFCode.Core.Common.Exceptions;
using ITFCode.Core.DTO.FilterOptions.Base;
using System.Linq.Expressions;
using System.Reflection;

namespace ITFCode.Core.Service.FilterHandlers.Base
{
    public abstract class FilterHandler<TFilter> where TFilter : FilterOption
    {
        #region Private Fields

        private readonly TFilter _filter;

        #endregion

        #region Protected Properties 

        protected TFilter Filter => _filter ?? throw new PropertyNotDefinedException(nameof(Filter));

        #endregion

        #region Constructors

        public FilterHandler(TFilter filter)
        {
            _filter = filter ?? throw new ArgumentNullException(nameof(filter));
        }

        #endregion

        #region Public Methods 

        public abstract Expression<Func<TEntity, bool>> Handle<TEntity>();

        #endregion

        #region Protected Methods 

        protected virtual Expression GetValue<T>(T value, Type propertyType)
        {
            return Expression.Convert(Expression.Constant(value), propertyType);
        }

        protected virtual Expression GetProperty(ParameterExpression item, string propertyName)
        {
            var parts = propertyName.Split('.');
            var property = parts.Aggregate<string, Expression>(item, Expression.Property);
            return property;
        }

        protected Type GetPropertyType<TEntity>() 
        {
            var property = typeof(TEntity).GetProperties()
                .FirstOrDefault(x => x.IsPublic() && x.Name == Filter.PropertyName)
                ?? throw new ArgumentNullException($"Public property '{Filter.PropertyName}' not defined in type '{typeof(TEntity).Name}'");

            return property.GetType();
        }

        #endregion
    }
}