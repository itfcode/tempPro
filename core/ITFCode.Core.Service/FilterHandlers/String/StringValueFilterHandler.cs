using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers.Base;
using System.Linq.Expressions;
using System.Net;

namespace ITFCode.Core.Service.FilterHandlers
{
    public class StringValueFilterHandler : FilterHandler<StringValueFilter>
    {
        #region Counstructors

        public StringValueFilterHandler(StringValueFilter filter) : base(filter) { }

        #endregion

        #region Public Methods

        public override Expression<Func<TEntity, bool>> Handle<TEntity>()
        {
            var item = Expression.Parameter(typeof(TEntity), "item");
            var property = Expression.Call(GetProperty(item, Filter.PropertyName), "ToUpper", null);
            var value = Expression.Constant(WebUtility.UrlDecode(Filter.Value.ToUpperInvariant()));

            string methodName;
            switch (Filter.MatchMode)
            {
                case StringFilterMatchMode.Equals:
                    methodName = "Equals";
                    break;
                case StringFilterMatchMode.StartsWith:
                    methodName = "StartsWith";
                    break;
                case StringFilterMatchMode.EndsWith:
                    methodName = "EndsWith";
                    break;
                case StringFilterMatchMode.NotEquals:
                    throw new ArgumentOutOfRangeException($"Rule not defined for '{Filter.MatchMode}'");
                    //var notEqualExpression = Expression.NotEqual(property, Expression.Constant(value));
                    //return Expression.Lambda<Func<TEntity, bool>>(notEqualExpression, item);
                case StringFilterMatchMode.Contains:
                    var isNotNullExpression = Expression.NotEqual(property, Expression.Constant(null));
                    var checkContainsExpression = Expression.Call(property, "Contains", null, value);
                    var notNullAndContainsExpression = Expression.AndAlso(isNotNullExpression, checkContainsExpression);
                    return Expression.Lambda<Func<TEntity, bool>>(notNullAndContainsExpression, item);
                default:
                    throw new ArgumentOutOfRangeException($"Rule not defined for '{Filter.MatchMode}'");
            }

            var method = typeof(string).GetMethod(methodName, new Type[] { typeof(string) }) 
                ?? throw new NullReferenceException($"Method '{methodName}' not found in type String");

            var body = Expression.Call(property, method, value);

            return Expression.Lambda<Func<TEntity, bool>>(body, item);
        }

        #endregion
    }
}
