using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers.Base;
using System.Linq.Expressions;
using System.Reflection;

namespace ITFCode.Core.Service.FilterHandlers
{
    public class StringListFilterHandler : FilterHandler<StringListFilter>
    {
        #region Constructions

        public StringListFilterHandler(StringListFilter filter) : base(filter) { }

        #endregion

        #region Public Methods 

        public override Expression<Func<TEntity, bool>> Handle<TEntity>()
        {
            var item = Expression.Parameter(typeof(TEntity), "item");
            var value = GetProperty(item, Filter.PropertyName);

            MethodInfo methodInfo = typeof(List<string>).GetMethod("Contains", new Type[] { typeof(string) }) ?? throw new NullReferenceException();
            ConstantExpression list = Expression.Constant(Filter.Values.Select(x => x).ToList());

            var body = Expression.Call(list, methodInfo, value);

            return Expression.Lambda<Func<TEntity, bool>>(body, item);
        }

        #endregion
    }
}