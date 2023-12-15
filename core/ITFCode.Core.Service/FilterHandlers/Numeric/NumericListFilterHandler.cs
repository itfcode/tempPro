using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.DTO.FilterOptions.Base;
using ITFCode.Core.Service.FilterHandlers.Base;
using System.Linq.Expressions;
using System.Reflection;

namespace ITFCode.Core.Service.FilterHandlers
{
    public class NumericListFilterHandler : FilterHandler<NumericListFilter>
    {
        #region Constructions

        public NumericListFilterHandler(NumericListFilter filter) : base(filter) { }

        #endregion

        #region Public Methods 

        public override Expression<Func<TEntity, bool>> Handle<TEntity>()
        {
            var item = Expression.Parameter(typeof(TEntity), "item");
            var property = GetProperty(item, Filter.PropertyName);

            var cort = GetMethodAndList(property.Type);

            MethodInfo? methodInfo = cort.Method;
            ConstantExpression? list = cort.Constant;

            //MethodInfo? methodInfo = typeof(List<double>).GetMethod("Contains", new Type[] { typeof(double) });
            //ConstantExpression? list = Expression.Constant(filterValues);

            if (methodInfo is null)
                throw new NullReferenceException($"Method List.Contains not defined for type 'double'");

            var body = Expression.Call(list, methodInfo, property);

            return Expression.Lambda<Func<TEntity, bool>>(body, item);
        }

        #endregion

        #region Private Method

        protected virtual List<TValue> GetFilterValues<TValue>()
        {
            return (Filter as FilterListOption<TValue>)?.Values ?? throw new NullReferenceException("Cannot get list of values");
        }

        public MethodInfo? GetMethod<T>() 
        {
            return typeof(List<T>).GetMethod("Contains", new Type[] { typeof(T) });
        }

        public ConstantExpression? GetConstantList<TValue>(Func<double, TValue> selector)
        {
            return Expression.Constant(Filter.Values.Select(selector).ToList());
        }

        private (MethodInfo? Method, ConstantExpression? Constant) GetMethodAndList(Type type)
        {
            if (type == typeof(int)) return (GetMethod<int>(), GetConstantList(x => (int)x));
            if (type == typeof(int?)) return (GetMethod<int?>(), GetConstantList(x => (int?)x));

            if (type == typeof(uint)) return (GetMethod<int>(), GetConstantList(x => (uint)x));
            if (type == typeof(uint?)) return (GetMethod<uint?>(), GetConstantList(x => (uint?)x));

            if (type == typeof(long)) return (GetMethod<long>(), GetConstantList(x => (long)x));
            if (type == typeof(long?)) return (GetMethod<long?>(), GetConstantList(x => (long?)x));

            if (type == typeof(ulong)) return (GetMethod<ulong>(), GetConstantList(x => (ulong)x));
            if (type == typeof(ulong?)) return (GetMethod<ulong?>(), GetConstantList(x => (ulong?)x));

            if (type == typeof(byte)) return (GetMethod<byte>(), GetConstantList(x => (byte)x));
            if (type == typeof(byte?)) return (GetMethod<byte?>(), GetConstantList(x => (byte?)x));

            if (type == typeof(sbyte)) return (GetMethod<sbyte>(), GetConstantList(x => (sbyte)x));
            if (type == typeof(sbyte?)) return (GetMethod<sbyte?>(), GetConstantList(x => (sbyte?)x));

            if (type == typeof(short)) return (GetMethod<short>(), GetConstantList(x => (short)x));
            if (type == typeof(short?)) return (GetMethod<short?>(), GetConstantList(x => (short?)x));

            if (type == typeof(ushort)) return (GetMethod<ushort>(), GetConstantList(x => (ushort)x));
            if (type == typeof(ushort?)) return (GetMethod<ushort?>(), GetConstantList(x => (ushort?)x));

            if (type == typeof(float)) return (GetMethod<float>(), GetConstantList(x => (float)x));
            if (type == typeof(float?)) return (GetMethod<float?>(), GetConstantList(x => (float?)x));

            if (type == typeof(double)) return (GetMethod<double>(), GetConstantList(x => (double)x));
            if (type == typeof(double?)) return (GetMethod<double?>(), GetConstantList(x => (double?)x));

            if (type == typeof(decimal)) return (GetMethod<decimal>(), GetConstantList(x => (decimal)x));
            if (type == typeof(decimal?)) return (GetMethod<decimal?>(), GetConstantList(x => (decimal?)x));

            throw new NotImplementedException();
        }


        #endregion
    }
}