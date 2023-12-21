using AutoFixture;
using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers;
using ITFCode.Core.Service.Tests.TestData;
using System.Linq.Expressions;

namespace ITFCode.Core.Service.Tests.FilterHandlers.ValueHandlers
{
    public class StringValueFilterHandler_Tests : BaseValueFilterHandlerBase_Tests<StringValueFilterHandler, StringValueFilter>
    {
        #region Facts

        [Theory, MemberData(nameof(TestData))]
        public void Handle_String_Simple_Test(int itemCount, StringFilterMatchMode matchMode)
        {
            static string valueGetter(TestSimpleClass x) => x.StringProperty;
            string propertyName = $"{nameof(TestSimpleClass.StringProperty)}";
            var items = GenerateSimpleData(itemCount);
            var filterValue = itemCount > 0 ? valueGetter(items.First()) : _fixture.Create<string>();

            var filter = new StringValueFilter
            {
                PropertyName = propertyName,
                Value = filterValue,
                MatchMode = matchMode
            };

            RunTest(
                items: items,
                predicate: new StringValueFilterHandler(filter).Handle<TestSimpleClass>(),
                filterValue: filterValue,
                matchMode: matchMode,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_String_Complex_Test(int itemCount, StringFilterMatchMode matchMode)
        {
            static string valueGetter(TestComplexClass x) => x.Property1.StringProperty;
            string propertyName = $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.StringProperty)}";
            var items = GenerateComplexData(itemCount);
            var filterValue = itemCount > 0 ? valueGetter(items.First()) : _fixture.Create<string>();

            var filter = new StringValueFilter
            {
                PropertyName = propertyName,
                Value = filterValue,
                MatchMode = matchMode
            };

            RunTest(
                items: items,
                predicate: new StringValueFilterHandler(filter).Handle<TestComplexClass>(),
                filterValue: filterValue,
                matchMode: matchMode,
                valueGetter: valueGetter);
        }

        #endregion

        #region Test Data 

        public static IEnumerable<object[]> TestData =>
            (new StringFilterMatchMode[]
            {
                StringFilterMatchMode.Equals,
                StringFilterMatchMode.Contains,
                StringFilterMatchMode.StartsWith,
                StringFilterMatchMode.EndsWith,
            })
            .SelectMany(x => (new int[] { STEP_0, STEP_1, STEP_4 })
                .Select(y => new object[] { y, x }))
            .ToList();

        #endregion

        #region Private Methods 

        private void RunTest<TClass>(ICollection<TClass> items, Expression<Func<TClass, bool>> predicate,
            string filterValue, StringFilterMatchMode matchMode, Func<TClass, string> valueGetter) where TClass : class
        {
            var filtered = items.AsQueryable()
                .Where(predicate)
                .ToList();

            var expectedCount = items.Count(x => CheckValueComparasion(valueGetter(x), filterValue, matchMode));

            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => CheckValueComparasion(valueGetter(x), filterValue, matchMode)));
        }

        private static bool CheckValueComparasion(string source, string value, StringFilterMatchMode matchMode)
            => matchMode switch
            {
                StringFilterMatchMode.Equals => source.Equals(value, StringComparison.InvariantCultureIgnoreCase),
                StringFilterMatchMode.StartsWith => source.StartsWith(value, StringComparison.InvariantCultureIgnoreCase),
                StringFilterMatchMode.EndsWith => source.EndsWith(value, StringComparison.InvariantCultureIgnoreCase),
                StringFilterMatchMode.Contains => source.Contains(value, StringComparison.InvariantCultureIgnoreCase),
                _ => throw new ArgumentException($"Invalid enum value for MatchMode: '{matchMode}'"),
            };

        #endregion
    }
}