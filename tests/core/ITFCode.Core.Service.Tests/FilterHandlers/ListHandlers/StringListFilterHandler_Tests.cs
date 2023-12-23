using AutoFixture;
using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers;
using ITFCode.Core.Service.Tests.TestData;

namespace ITFCode.Core.Service.Tests.FilterHandlers.ListHandlers
{
    public class StringListFilterHandler_Tests : BaseValueFilterHandlerBase_Tests<StringListFilterHandler, StringListFilter>
    {
        #region Facts

        [Theory, MemberData(nameof(TestData))]
        public void Handle_String_Simple_Test(int itemCount)
        {
            var propertyName = nameof(TestSimpleClass.StringProperty);
            static string valueGetter(TestSimpleClass x) => x.StringProperty;

            var items = GenerateSimpleData(itemCount);
            var filterValues = items.Count > 0
                ? items.Take(2).Select(valueGetter).ToList()
                : new List<string> { _fixture.Create<string>() };

            ExecuteTest(
                items: items,
                propertyName: propertyName,
                values: filterValues,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_String_Complex_Test(int itemCount)
        {
            var propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.StringProperty)}";
            static string valueGetter(TestComplexClass x) => x.PropertyA.StringProperty;

            var complexItems = GenerateComplexData(itemCount);
            var complexValues = complexItems.Count > 0
                ? complexItems.Take(2).Select(valueGetter).ToList()
                : new List<string> { _fixture.Create<string>() };

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

        private static void ExecuteTest<TClass>(ICollection<TClass> items, string propertyName, List<string> values, Func<TClass, string> valueGetter)
        {
            var filter = new StringListFilter
            {
                PropertyName = propertyName,
                Values = values.ToList(),
            };

            var expr = new StringListFilterHandler(filter).Handle<TClass>();

            var filtered = items.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = items.Count(x => values.Contains(valueGetter(x)));

            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => values.Contains(valueGetter(x))));
        }

        #endregion
    }
}