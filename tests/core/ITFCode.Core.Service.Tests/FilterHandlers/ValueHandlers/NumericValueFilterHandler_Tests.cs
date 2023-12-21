using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers;
using ITFCode.Core.Service.Tests.TestData;

namespace ITFCode.Core.Service.Tests.FilterHandlers.ValueHandlers
{
    public class NumericValueFilterHandler_Tests : BaseValueFilterHandlerBase_Tests<NumericValueFilterHandler, NumericValueFilter>
    {
        #region Sbyte & Sbyte?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_SByte_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.SByteProperty),
                matchMode: matchMode,
                valueGetter: x => x.SByteProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_SByteNull_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.SByteNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.SByteNullProperty ?? throw new ArgumentNullException());
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_SByte_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.SByteProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.SByteProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_SByteNull_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.SByteNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.SByteNullProperty ?? throw new ArgumentNullException());
        }

        #endregion

        #region Byte & Byte?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Byte_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.ByteProperty),
                matchMode: matchMode,
                valueGetter: x => x.ByteProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ByteNull_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.ByteNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.ByteNullProperty ?? throw new ArgumentNullException());
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Byte_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.ByteProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.ByteProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ByteNull_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.ByteNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.ByteNullProperty ?? throw new ArgumentNullException());
        }

        #endregion

        #region Short & Short?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Short_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.ShortProperty),
                matchMode: matchMode,
                valueGetter: x => x.ShortProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ShortNull_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.ShortNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.ShortNullProperty ?? throw new ArgumentNullException());
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Short_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.ShortProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.ShortProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ShortNull_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.ShortNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.ShortNullProperty ?? throw new ArgumentNullException());
        }

        #endregion

        #region Ushort & Ushort?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UShort_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.UShortProperty),
                matchMode: matchMode,
                valueGetter: x => x.UShortProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UShortNull_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.UShortNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.UShortNullProperty ?? throw new ArgumentNullException());
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UShort_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.UShortProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.UShortProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UShortNull_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.UShortNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.UShortNullProperty ?? throw new ArgumentNullException());
        }

        #endregion

        #region Int & Int?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Int_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.IntProperty),
                matchMode: matchMode,
                valueGetter: x => x.IntProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_IntNull_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.IntNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.IntNullProperty ?? throw new ArgumentNullException());
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Int_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.IntProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.IntProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_IntNull_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.IntNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.IntNullProperty ?? throw new ArgumentNullException());
        }

        #endregion

        #region UInt & UInt?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UInt_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.UIntProperty),
                matchMode: matchMode,
                valueGetter: x => x.UIntProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UIntNull_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.UIntNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.UIntNullProperty ?? throw new ArgumentNullException());
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UInt_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.UIntProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.UIntProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UIntNull_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.UIntNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.UIntNullProperty ?? throw new ArgumentNullException());
        }

        #endregion

        #region Long & Long?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Long_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.LongProperty),
                matchMode: matchMode,
                valueGetter: x => x.LongProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_LongNull_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.LongNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.LongNullProperty ?? throw new ArgumentNullException());
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Long_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.LongProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.LongProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_LongNull_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.LongNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.LongNullProperty ?? throw new ArgumentNullException());
        }

        #endregion

        #region ULong & ULong?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ULong_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.ULongProperty),
                matchMode: matchMode,
                valueGetter: x => x.ULongProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ULongNull_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.ULongNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.ULongNullProperty ?? throw new ArgumentNullException());
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ULong_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.ULongProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.ULongProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ULongNull_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.ULongNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.ULongNullProperty ?? throw new ArgumentNullException());
        }

        #endregion

        #region Float & Float?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Float_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.FloatProperty),
                matchMode: matchMode,
                valueGetter: x => x.FloatProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_FloatNull_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.FloatNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.FloatNullProperty ?? throw new ArgumentNullException());
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Float_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.FloatProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.FloatProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_FloatNull_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.FloatNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.FloatNullProperty ?? throw new ArgumentNullException());
        }

        #endregion

        #region Double & Double?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Double_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.DoubleProperty),
                matchMode: matchMode,
                valueGetter: x => x.DoubleProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_DoubleNull_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.DoubleNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.DoubleNullProperty ?? throw new ArgumentNullException());
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Double_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.DoubleProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.DoubleProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_DoubleNull_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.DoubleNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.DoubleNullProperty ?? throw new ArgumentNullException());
        }

        #endregion

        #region Decimal & Decimal?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Decimal_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.DecimalProperty),
                matchMode: matchMode,
                valueGetter: x => x.DecimalProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_DecimalNull_Simple_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.DecimalNullProperty),
                matchMode: matchMode,
                valueGetter: x => x.DecimalNullProperty ?? throw new ArgumentNullException());
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Decimal_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.DecimalProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.DecimalProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_DecimalNull_Complex_Test(int itemCount, NumericFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.DecimalNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.DecimalNullProperty ?? throw new ArgumentNullException());
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