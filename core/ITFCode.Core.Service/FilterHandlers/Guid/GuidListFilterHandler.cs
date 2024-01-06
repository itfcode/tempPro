﻿using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers.Base;
using System.Linq.Expressions;
using System.Reflection;

namespace ITFCode.Core.Service.FilterHandlers
{
    public class GuidListFilterHandler : FilterHandler<GuidListFilter>
    {
        #region Constructions

        public GuidListFilterHandler(GuidListFilter filter) : base(filter) { }

        #endregion

        #region Public Methods 

        public override Expression<Func<TEntity, bool>> Handle<TEntity>()
        {
            var item = Expression.Parameter(typeof(TEntity), "item");
            var value = GetProperty(item, Filter.PropertyName);

            MethodInfo methodInfo;
            ConstantExpression list;

            if (value.Type == typeof(Guid?))
            {
                methodInfo = typeof(List<Guid?>).GetMethod("Contains", new Type[] { typeof(Guid?) })
                    ?? throw new NullReferenceException("Method 'Contains' not found in type 'Guid?'");

                list = Expression.Constant(Filter.Values.Select(x => (Guid?)x).ToList());
            }
            else
            {
                methodInfo = typeof(List<Guid>).GetMethod("Contains", new Type[] { typeof(Guid) })
                    ?? throw new NullReferenceException("Method 'Contains' not found in type 'Guid'");

                list = Expression.Constant(Filter.Values);
            }

            var body = Expression.Call(list, methodInfo, value);

            return Expression.Lambda<Func<TEntity, bool>>(body, item);
        }

        #endregion
    }
}