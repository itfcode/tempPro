using AutoFixture;
using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers;
using ITFCode.Core.Service.Tests.TestData;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class NumericListFilterHandler_Tests : BaseListFilterHandlerBase_Tests<NumericListFilterHandler, NumericListFilter>
    {
        #region Sbyte & Sbyte?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Sbyte_Test(int itemCount)
        {
            var simpleItems = GenerateSimpleData(itemCount);
            var simpleValues = simpleItems.Count > 0
                ? simpleItems.Take(2).Select(x => Convert.ToDouble(x.SbyteProperty)).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: simpleItems,
                propertyName: nameof(TestSimpleClass.SbyteProperty),
                values: simpleValues,
                valueGetter: x => x.SbyteProperty);

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(x.Property1.SbyteProperty)).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.SbyteProperty)}",
                values: complexValues,
                valueGetter: x => x.Property1.SbyteProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Decimal_Test(int itemCount)
        {
            var simpleItems = GenerateSimpleData(itemCount);
            var simpleValues = simpleItems.Count > 0
                ? simpleItems.Take(2).Select(x => Convert.ToDouble(x.DecimalProperty)).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: simpleItems,
                propertyName: nameof(TestSimpleClass.DecimalProperty),
                values: simpleValues,
                valueGetter: x => x.DecimalProperty);

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(x.Property1.DecimalProperty)).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.DecimalProperty)}",
                values: complexValues,
                valueGetter: x => x.Property1.DecimalProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Float_Test(int itemCount)
        {
            var simpleItems = GenerateSimpleData(itemCount);
            var simpleValues = simpleItems.Count > 0
                ? simpleItems.Take(2).Select(x => Convert.ToDouble(x.FloatProperty)).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: simpleItems,
                propertyName: nameof(TestSimpleClass.FloatProperty),
                values: simpleValues,
                valueGetter: x => x.FloatProperty);

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(x.Property1.FloatProperty)).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.FloatProperty)}",
                values: complexValues,
                valueGetter: x => x.Property1.FloatProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Double_Test(int itemCount)
        {
            var simpleItems = GenerateSimpleData(itemCount);
            var simpleValues = simpleItems.Count > 0
                ? simpleItems.Take(2).Select(x => Convert.ToDouble(x.DoubleProperty)).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: simpleItems,
                propertyName: nameof(TestSimpleClass.DoubleProperty),
                values: simpleValues,
                valueGetter: x => x.DoubleProperty);

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(x => Convert.ToDouble(x.Property1.DoubleProperty)).ToList()
                : new List<double> { _fixture.Create<double>() };

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.DoubleProperty)}",
                values: complexValues,
                valueGetter: x => x.Property1.DoubleProperty);
        }

        #endregion

        #region Test Data

        public static IEnumerable<object[]> TestData =>
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
