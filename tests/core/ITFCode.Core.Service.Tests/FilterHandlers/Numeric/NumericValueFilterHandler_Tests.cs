using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers;
using ITFCode.Core.Service.Tests.TestData;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class NumericValueFilterHandler_Tests : BaseValueFilterHandlerBase_Tests<NumericValueFilterHandler, NumericValueFilter>
    {
        #region Sbyte & Sbyte?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Sbyte_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.SbyteProperty),
                matchMode: matchMode,
                valueGetter: x => x.SbyteProperty);

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.SbyteProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.SbyteProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_SbyteNull_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteSimpleTest(
                count: itemCount,
                propertyName: nameof(TestSimpleClass.SbyteNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.SbyteNullProperty ?? throw new NullReferenceException("Not defined"));

            ExecuteComplexTest(
                count: itemCount,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.SbyteNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.SbyteNullProperty ?? throw new NullReferenceException("Not defined"));
        }

        #endregion

        #region Short & Short?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Short_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteSimpleTest(
                count: itemCount,
                propertyName: nameof(TestSimpleClass.ShortProperty),
                matchMode: matchMode,
                valueGetter: x => x.ShortProperty);

            ExecuteComplexTest(
                count: itemCount,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.ShortProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.ShortProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ShortNull_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteSimpleTest(
                count: itemCount,
                propertyName: nameof(TestSimpleClass.ShortNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.ShortNullProperty ?? throw new NullReferenceException("Not defined"));

            ExecuteComplexTest(
                count: itemCount,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.ShortNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.ShortNullProperty ?? throw new NullReferenceException("Not defined"));
        }

        #endregion

        #region Ushort & Ushort?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UShort_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteSimpleTest(
                count: itemCount,
                propertyName: nameof(TestSimpleClass.UshortProperty),
                matchMode: matchMode,
                valueGetter: x => x.UshortProperty);

            ExecuteComplexTest(
                count: itemCount,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.UshortProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.UshortProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UShortNull_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteSimpleTest(
                count: itemCount,
                propertyName: nameof(TestSimpleClass.UshortNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.UshortNullProperty ?? throw new NullReferenceException("Not defined"));

            ExecuteComplexTest(
                count: itemCount,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.UshortNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.UshortNullProperty ?? throw new NullReferenceException("Not defined"));
        }

        #endregion

        #region Int & Int?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Int_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteSimpleTest(
                count: itemCount,
                propertyName: nameof(TestSimpleClass.IntProperty),
                matchMode: matchMode,
                valueGetter: x => x.IntProperty);

            ExecuteComplexTest(
                count: itemCount,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.IntProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.IntProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_IntNull_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteSimpleTest(
                count: itemCount,
                propertyName: nameof(TestSimpleClass.IntNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.IntNullProperty ?? throw new NullReferenceException("Not defined"));

            ExecuteComplexTest(
                count: itemCount,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.IntNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.IntNullProperty ?? throw new NullReferenceException("Not defined"));
        }

        #endregion

        #region UInt & UInt?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UInt_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteSimpleTest(
                count: itemCount,
                propertyName: nameof(TestSimpleClass.UIntProperty),
                matchMode: matchMode,
                valueGetter: x => x.UIntProperty);

            ExecuteComplexTest(
                count: itemCount,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.UIntProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.UIntProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UIntNull_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteSimpleTest(
                count: itemCount,
                propertyName: nameof(TestSimpleClass.UIntNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.UIntNullProperty ?? throw new NullReferenceException("Not defined"));

            ExecuteComplexTest(
                count: itemCount,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.UIntNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.UIntNullProperty ?? throw new NullReferenceException("Not defined"));
        }

        #endregion

        #region Long & Long?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Long_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteSimpleTest(
                count: itemCount,
                propertyName: nameof(TestSimpleClass.LongProperty),
                matchMode: matchMode,
                valueGetter: x => x.LongProperty);

            ExecuteComplexTest(
                count: itemCount,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.LongProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.LongProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_LongNull_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteSimpleTest(
                count: itemCount,
                propertyName: nameof(TestSimpleClass.LongNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.LongNullProperty ?? throw new NullReferenceException("Not defined"));

            ExecuteComplexTest(
                count: itemCount,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.LongNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.LongNullProperty ?? throw new NullReferenceException("Not defined"));
        }

        #endregion

        #region ULong & ULong?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ULong_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteSimpleTest(
                count: itemCount,
                propertyName: nameof(TestSimpleClass.ULongProperty),
                matchMode: matchMode,
                valueGetter: x => x.ULongProperty);

            ExecuteComplexTest(
                count: itemCount,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.ULongProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.ULongProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ULongNull_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteSimpleTest(
                count: itemCount,
                propertyName: nameof(TestSimpleClass.ULongNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.ULongNullProperty ?? throw new NullReferenceException("Not defined"));

            ExecuteComplexTest(
                count: itemCount,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.ULongNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.ULongNullProperty ?? throw new NullReferenceException("Not defined"));
        }

        #endregion

        #region Float & Float?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Float_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteSimpleTest(
                count: itemCount,
                propertyName: nameof(TestSimpleClass.FloatProperty),
                matchMode: matchMode,
                valueGetter: x => x.FloatProperty);

            ExecuteComplexTest(
                count: itemCount,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.FloatProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.FloatProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_FloatNull_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteSimpleTest(
                count: itemCount,
                propertyName: nameof(TestSimpleClass.FloatNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.FloatNullProperty ?? throw new NullReferenceException("Not defined"));

            ExecuteComplexTest(
                count: itemCount,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.FloatNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.FloatNullProperty ?? throw new NullReferenceException("Not defined"));
        }

        #endregion

        #region Double & Double?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Double_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteSimpleTest(
                count: itemCount,
                propertyName: nameof(TestSimpleClass.DoubleProperty),
                matchMode: matchMode,
                valueGetter: x => x.DoubleProperty);

            ExecuteComplexTest(
                count: itemCount,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.DoubleProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.DoubleProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_DoubleNull_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteSimpleTest(
                count: itemCount,
                propertyName: nameof(TestSimpleClass.FloatNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.FloatNullProperty ?? throw new NullReferenceException("Not defined"));

            ExecuteComplexTest(
                count: itemCount,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.FloatNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.FloatNullProperty ?? throw new NullReferenceException("Not defined"));
        }

        #endregion

        #region Decimal & Decimal?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Decimal_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteSimpleTest(
                count: itemCount,
                propertyName: nameof(TestSimpleClass.DecimalProperty),
                matchMode: matchMode,
                valueGetter: x => x.DecimalProperty);

            ExecuteComplexTest(
                count: itemCount,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.DecimalProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.DecimalProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_DecimalNull_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteSimpleTest(
                count: itemCount,
                propertyName: nameof(TestSimpleClass.DecimalNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.DecimalNullProperty ?? throw new NullReferenceException("Not defined"));

            ExecuteComplexTest(
                count: itemCount,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.DecimalNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.DecimalNullProperty ?? throw new NullReferenceException("Not defined"));
        }

        #endregion

        #region Test Data 

        public static IEnumerable<object[]> TestData =>
            (new NumericFilterMatchMode[]
            {
                NumericFilterMatchMode.Equals,
                NumericFilterMatchMode.LessThan,
                NumericFilterMatchMode.LessThanOrEquals,
                NumericFilterMatchMode.GreaterThan,
                NumericFilterMatchMode.GreaterThanOrEquals
            })
            .SelectMany(x => (new int[] { STEP_1, STEP_4 }).Select(y => new object[] { y, x }))
            .ToList();

        #endregion

        #region Private Methods 

        private void ExecuteTest<TClass, TValue>(ICollection<TClass> items, string propertyName, NumericFilterMatchMode matchMode, Func<TClass, TValue> valueGetter)
            where TValue : IComparable<TValue>
        {
            int position = items.Count / 2;

            var testValues = items.ToList();

            var value = valueGetter(testValues.Skip(position).First());

            var filter = new NumericValueFilter
            {
                PropertyName = propertyName,
                Value = Convert.ToDouble(value),
                MatchMode = matchMode
            };

            var expr = new NumericValueFilterHandler(filter).Handle<TClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => CheckValueComparasion(valueGetter(x), value, matchMode));

            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => CheckValueComparasion(valueGetter(x), value, matchMode)));
        }

        private void ExecuteSimpleTest<TValue>(int count, string propertyName, NumericFilterMatchMode matchMode, Func<TestSimpleClass, TValue> valueGetter) where TValue : IComparable<TValue>
        {
            int position = count / 2;

            var testValues = GenerateSimpleData(count);
            var value = valueGetter(testValues.Skip(position).First());

            var filter = new NumericValueFilter
            {
                PropertyName = propertyName,
                Value = Convert.ToDouble(value),
                MatchMode = matchMode
            };

            var expr = new NumericValueFilterHandler(filter).Handle<TestSimpleClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => CheckValueComparasion(valueGetter(x), value, matchMode));

            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => CheckValueComparasion(valueGetter(x), value, matchMode)));
        }

        private void ExecuteComplexTest<TValue>(int count, string propertyName, NumericFilterMatchMode matchMode, Func<TestComplexClass, TValue> valueGetter) where TValue : IComparable<TValue>
        {
            int position = count / 2;

            var testValues = GenerateComplexData(count);
            var value = valueGetter(testValues.Skip(position).First());

            var filter = new NumericValueFilter
            {
                PropertyName = propertyName,
                Value = Convert.ToDouble(value),
                MatchMode = matchMode
            };

            var expr = new NumericValueFilterHandler(filter).Handle<TestComplexClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => CheckValueComparasion(valueGetter(x), value, matchMode));

            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => CheckValueComparasion(valueGetter(x), value, matchMode)));
        }

        private bool CheckValueComparasion<TValue>(TValue source, TValue value, NumericFilterMatchMode matchMode) where TValue : IComparable<TValue>
            => matchMode switch
            {
                NumericFilterMatchMode.Equals => source.Equals(value),
                NumericFilterMatchMode.LessThan => source.CompareTo(value) < 0,
                NumericFilterMatchMode.LessThanOrEquals => source.CompareTo(value) <= 0,
                NumericFilterMatchMode.GreaterThan => source.CompareTo(value) > 0,
                NumericFilterMatchMode.GreaterThanOrEquals => source.CompareTo(value) >= 0,
                _ => throw new ArgumentException("Invalid enum value for MatchMode"),
            };

        #endregion
    }
}