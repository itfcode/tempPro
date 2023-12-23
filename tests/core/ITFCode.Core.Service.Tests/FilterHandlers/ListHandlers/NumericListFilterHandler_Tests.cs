using AutoFixture;
using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers;
using ITFCode.Core.Service.Tests.TestData;

namespace ITFCode.Core.Service.Tests.FilterHandlers.ListHandlers
{
    public class NumericListFilterHandler_Tests : BaseListFilterHandlerBase_Tests<NumericListFilterHandler, NumericListFilter>
    {
        #region Sbyte & Sbyte?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Sbyte_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.SByteProperty);
            static sbyte valueGetter(TestSimpleClass x) => x.SByteProperty;

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_SByteNull_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.SByteNullProperty);
            static sbyte valueGetter(TestSimpleClass x) => x.SByteNullProperty ?? throw new ArgumentNullException();

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_SByte_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.SByteProperty)}";
            static sbyte valueGetter(TestComplexClass x) => x.PropertyA.SByteProperty;

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_SByteNull_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.SByteNullProperty)}";
            static sbyte valueGetter(TestComplexClass x) => x.PropertyA.SByteNullProperty ?? throw new ArgumentNullException();

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        #endregion

        #region Byte & Byte?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Byte_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.ByteProperty);
            static byte valueGetter(TestSimpleClass x) => x.ByteProperty;

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ByteNull_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.ByteNullProperty);
            static byte valueGetter(TestSimpleClass x) => x.ByteNullProperty ?? throw new ArgumentNullException();

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Byte_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.ByteProperty)}";
            static byte valueGetter(TestComplexClass x) => x.PropertyA.ByteProperty;

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ByteNull_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.ByteNullProperty)}";
            static byte valueGetter(TestComplexClass x) => x.PropertyA.ByteNullProperty ?? throw new ArgumentNullException();

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }
        #endregion 

        #region Short & Short?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Short_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.ShortProperty);
            static short valueGetter(TestSimpleClass x) => x.ShortProperty;

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ShortNull_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.ShortNullProperty);
            static short valueGetter(TestSimpleClass x) => x.ShortNullProperty ?? throw new ArgumentNullException();

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Short_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.ShortProperty)}";
            static short valueGetter(TestComplexClass x) => x.PropertyA.ShortProperty;

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ShortNull_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.ShortNullProperty)}";
            static short valueGetter(TestComplexClass x) => x.PropertyA.ShortNullProperty ?? throw new ArgumentNullException();

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        #endregion

        #region UShort & UShort?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UShort_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.UShortProperty);
            static ushort valueGetter(TestSimpleClass x) => x.UShortProperty;

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UShortNull_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.UShortNullProperty);
            static ushort valueGetter(TestSimpleClass x) => x.UShortNullProperty ?? throw new ArgumentNullException();

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UShort_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.UShortProperty)}";
            static ushort valueGetter(TestComplexClass x) => x.PropertyA.UShortProperty;

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UShortNull_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.UShortNullProperty)}";
            static ushort valueGetter(TestComplexClass x) => x.PropertyA.UShortNullProperty ?? throw new ArgumentNullException();

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        #endregion

        #region Int & Int?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Int_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.IntProperty);
            static int valueGetter(TestSimpleClass x) => x.IntProperty;

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_IntNull_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.IntNullProperty);
            static int valueGetter(TestSimpleClass x) => x.IntNullProperty ?? throw new ArgumentNullException();

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Int_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.IntProperty)}";
            static int valueGetter(TestComplexClass x) => x.PropertyA.IntProperty;

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }
        [Theory, MemberData(nameof(TestData))]

        public void Handle_IntNull_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.IntNullProperty)}";
            static int valueGetter(TestComplexClass x) => x.PropertyA.IntNullProperty ?? throw new ArgumentNullException();

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        #endregion

        #region UInt & UInt?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Uint_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.UIntProperty);
            static uint valueGetter(TestSimpleClass x) => x.UIntProperty;

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UintNull_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.UIntNullProperty);
            static uint valueGetter(TestSimpleClass x) => x.UIntNullProperty ?? throw new ArgumentNullException();

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Uint_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.UIntProperty)}";
            static uint valueGetter(TestComplexClass x) => x.PropertyA.UIntProperty;

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_UintNull_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.UIntNullProperty)}";
            static uint valueGetter(TestComplexClass x) => x.PropertyA.UIntNullProperty ?? throw new ArgumentNullException();

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        #endregion

        #region Long & Long?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Long_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.LongProperty);
            static long valueGetter(TestSimpleClass x) => x.LongProperty;

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_LongNull_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.LongNullProperty);
            static long valueGetter(TestSimpleClass x) => x.LongNullProperty ?? throw new ArgumentNullException();

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Long_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.LongProperty)}";
            static long valueGetter(TestComplexClass x) => x.PropertyA.LongProperty;

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_LongNull_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.LongNullProperty)}";
            static long valueGetter(TestComplexClass x) => x.PropertyA.LongNullProperty ?? throw new ArgumentNullException();

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        #endregion

        #region ULong & ULong?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ULong_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.ULongProperty);
            static ulong valueGetter(TestSimpleClass x) => x.ULongProperty;

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ULongNull_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.ULongNullProperty);
            static ulong valueGetter(TestSimpleClass x) => x.ULongNullProperty ?? throw new ArgumentNullException(); ;

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ULong_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.ULongProperty)}";
            static ulong valueGetter(TestComplexClass x) => x.PropertyA.ULongProperty;

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_ULongNull_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.ULongNullProperty)}";
            static ulong valueGetter(TestComplexClass x) => x.PropertyA.ULongNullProperty ?? throw new ArgumentNullException();

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        #endregion

        #region Decimal & Decimal?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Decimal_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.DecimalProperty);
            static decimal valueGetter(TestSimpleClass x) => x.DecimalProperty;

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_DecimalNull_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.DecimalNullProperty);
            static decimal valueGetter(TestSimpleClass x) => x.DecimalNullProperty ?? throw new ArgumentNullException();

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Decimal_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.DecimalProperty)}";
            static decimal valueGetter(TestComplexClass x) => x.PropertyA.DecimalProperty;

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_DecimalNull_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.DecimalNullProperty)}";
            static decimal valueGetter(TestComplexClass x) => x.PropertyA.DecimalNullProperty ?? throw new ArgumentNullException();

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        #endregion

        #region Float & Float?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Float_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.FloatProperty);
            static float valueGetter(TestSimpleClass x) => x.FloatProperty;

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_FloatNull_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.FloatNullProperty);
            static float valueGetter(TestSimpleClass x) => x.FloatNullProperty ?? throw new ArgumentNullException();

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Float_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.FloatProperty)}";
            static float valueGetter(TestComplexClass x) => x.PropertyA.FloatProperty;

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_FloatNull_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.FloatNullProperty)}";
            static float valueGetter(TestComplexClass x) => x.PropertyA.FloatNullProperty ?? throw new ArgumentNullException();

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        #endregion

        #region Double & Double?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Double_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.DoubleProperty);
            static double valueGetter(TestSimpleClass x) => x.DoubleProperty;

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_DoubleNull_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.DoubleNullProperty);
            static double valueGetter(TestSimpleClass x) => x.DoubleNullProperty ?? throw new ArgumentNullException();

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Double_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.DoubleProperty)}";
            static double valueGetter(TestComplexClass x) => x.PropertyA.DoubleProperty;

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_DoubleNull_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.DoubleNullProperty)}";
            static double valueGetter(TestComplexClass x) => x.PropertyA.DoubleNullProperty ?? throw new ArgumentNullException();

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(valueGetter(x))).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: propertyName,
                values: complexValues,
                valueGetter: valueGetter);
        }

        #endregion

        #region Test Data

        public static IEnumerable<object[]> TestData =>
            (new int[] { STEP_0, STEP_1, STEP_2, STEP_4 })
            .Select(y => new object[] { y })
            .ToList();

        public static IEnumerable<object[]> TestData1 =>
            (new int[] { STEP_0, STEP_1, STEP_2, STEP_4 })
            .Select(y => new object[] { y })
            .ToList();

        #endregion

        #region Private 

        private void ExecuteTest<TClass, TValue>(ICollection<TClass> items, string propertyName, List<double> values, Func<TClass, TValue> valueGetter)
            where TValue : IComparable<TValue>
        {
            var filter = new NumericListFilter
            {
                PropertyName = propertyName,
                Values = values.ToList(),
            };

            var expr = new NumericListFilterHandler(filter).Handle<TClass>();

            var filtered = items.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = items.Count(x => values.Contains(Convert.ToDouble(valueGetter(x))));

            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => values.Contains(Convert.ToDouble(valueGetter(x)))));
        }

        #endregion
    }
}
