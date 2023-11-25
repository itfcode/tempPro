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
            ExecuteTest(count: itemCount, propertyName: nameof(TestSimpleClass.SbyteProperty), matchMode: matchMode, x => x.SbyteProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_SbyteNull_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(count: itemCount, propertyName: nameof(TestSimpleClass.SbyteNullProperty), matchMode: matchMode, x => x.SbyteNullProperty.Value);
        }

        #endregion

        #region Short & Short?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Short_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(count: itemCount, propertyName: nameof(TestSimpleClass.ShortProperty), matchMode: matchMode, x => x.ShortProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ShortNull_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(count: itemCount, propertyName: nameof(TestSimpleClass.ShortNullProperty), matchMode: matchMode, x => x.ShortNullProperty.Value);
        }

        #endregion

        #region Ushort & Ushort?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UShort_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(count: itemCount, propertyName: nameof(TestSimpleClass.UshortProperty), matchMode: matchMode, x => x.UshortProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UShortNull_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(count: itemCount, propertyName: nameof(TestSimpleClass.UshortNullProperty), matchMode: matchMode, x => x.UshortNullProperty.Value);
        }

        #endregion

        #region Int & Int?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Int_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(count: itemCount, propertyName: nameof(TestSimpleClass.IntProperty), matchMode: matchMode, x => x.IntProperty);
        }

        #endregion

        #region UInt & UInt?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UInt_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(count: itemCount, propertyName: nameof(TestSimpleClass.UIntProperty), matchMode: matchMode, x => x.UIntProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UIntNull_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(count: itemCount, propertyName: nameof(TestSimpleClass.UIntNullProperty), matchMode: matchMode, x => x.UIntNullProperty.Value);
        }

        #endregion

        #region Long & Long?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Long_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(count: itemCount, propertyName: nameof(TestSimpleClass.LongProperty), matchMode: matchMode, x => x.LongProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_LongNull_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(count: itemCount, propertyName: nameof(TestSimpleClass.LongNullProperty), matchMode: matchMode, x => x.LongNullProperty.Value);
        }

        #endregion

        #region ULong & ULong?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ULong_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(count: itemCount, propertyName: nameof(TestSimpleClass.ULongProperty), matchMode: matchMode, x => x.ULongProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ULongNull_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(count: itemCount, propertyName: nameof(TestSimpleClass.ULongNullProperty), matchMode: matchMode, x => x.ULongNullProperty.Value);
        }

        #endregion

        #region Float & Float?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Float_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(count: itemCount, propertyName: nameof(TestSimpleClass.FloatProperty), matchMode: matchMode, x => x.FloatProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_FloatNull_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(count: itemCount, propertyName: nameof(TestSimpleClass.FloatNullProperty), matchMode: matchMode, x => x.FloatNullProperty.Value);
        }

        #endregion

        #region Double & Double?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Double_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(count: itemCount, propertyName: nameof(TestSimpleClass.DoubleProperty), matchMode: matchMode, x => x.DoubleProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_DoubleNull_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(count: itemCount, propertyName: nameof(TestSimpleClass.DoubleNullProperty), matchMode: matchMode, x => x.DoubleNullProperty.Value);
        }

        #endregion

        #region Decimal & Decimal?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Decimal_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(count: itemCount, propertyName: nameof(TestSimpleClass.DecimalProperty), matchMode: matchMode, x => x.DecimalProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_DecimalNull_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(count: itemCount, propertyName: nameof(TestSimpleClass.DecimalNullProperty), matchMode: matchMode, x => x.DecimalNullProperty.Value);
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

        private void ExecuteTest<TValue>(int count, string propertyName, NumericFilterMatchMode matchMode, Func<TestSimpleClass, TValue> getValue) where TValue : IComparable<TValue>
        {
            int position = count / 2;

            var testValues = GenerateData(count);
            var value = getValue(testValues.Skip(position).First());

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

            var expectedCount = testValues.Count(x => CheckValueComparasion(getValue(x), value, matchMode));

            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => CheckValueComparasion(getValue(x), value, matchMode)));
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