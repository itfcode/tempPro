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

            var cort = GetMethodAndConstant(property.Type);

            MethodInfo? methodInfo = cort.Method;
            ConstantExpression? list = cort.Constant;

            if (methodInfo is null)
                throw new NullReferenceException($"Method List.Contains not defined for type 'double'");

            var body = Expression.Call(list, methodInfo, property);

            return Expression.Lambda<Func<TEntity, bool>>(body, item);
        }

        #endregion

        #region Private Method

        public MethodInfo? GetMethod<T>()
            => typeof(List<T>).GetMethod("Contains", new Type[] { typeof(T) });

        public ConstantExpression? GetConstantList<TValue>(Func<double, TValue> selector)
            => Expression.Constant(Filter.Values.Select(selector).ToList());

        private (MethodInfo? Method, ConstantExpression? Constant) GetMethodAndConstant(Type type)
            => type == typeof(int) ? (GetMethod<int>(), GetConstantList(x => (int)x))
            : type == typeof(int?) ? (GetMethod<int?>(), GetConstantList(x => (int?)x))
            : type == typeof(uint) ? (GetMethod<uint>(), GetConstantList(x => (uint)x))
            : type == typeof(uint?) ? (GetMethod<uint?>(), GetConstantList(x => (uint?)x))
            : type == typeof(long) ? (GetMethod<long>(), GetConstantList(x => (long)x))
            : type == typeof(long?) ? (GetMethod<long?>(), GetConstantList(x => (long?)x))
            : type == typeof(ulong) ? (GetMethod<ulong>(), GetConstantList(x => (ulong)x))
            : type == typeof(ulong?) ? (GetMethod<ulong?>(), GetConstantList(x => (ulong?)x))
            : type == typeof(byte) ? (GetMethod<byte>(), GetConstantList(x => (byte)x))
            : type == typeof(byte?) ? (GetMethod<byte?>(), GetConstantList(x => (byte?)x))
            : type == typeof(sbyte) ? (GetMethod<sbyte>(), GetConstantList(x => (sbyte)x))
            : type == typeof(sbyte?) ? (GetMethod<sbyte?>(), GetConstantList(x => (sbyte?)x))
            : type == typeof(short) ? (GetMethod<short>(), GetConstantList(x => (short)x))
            : type == typeof(short?) ? (GetMethod<short?>(), GetConstantList(x => (short?)x))
            : type == typeof(ushort) ? (GetMethod<ushort>(), GetConstantList(x => (ushort)x))
            : type == typeof(ushort?) ? (GetMethod<ushort?>(), GetConstantList(x => (ushort?)x))
            : type == typeof(float) ? (GetMethod<float>(), GetConstantList(x => (float)x))
            : type == typeof(float?) ? (GetMethod<float?>(), GetConstantList(x => (float?)x))
            : type == typeof(double) ? (GetMethod<double>(), GetConstantList(x => (double)x))
            : type == typeof(double?) ? (GetMethod<double?>(), GetConstantList(x => (double?)x))
            : type == typeof(decimal) ? (GetMethod<decimal>(), GetConstantList(x => (decimal)x))
            : type == typeof(decimal?) ? (GetMethod<decimal?>(), GetConstantList(x => (decimal?)x))
            : throw new NotImplementedException();

        #endregion
    }
}