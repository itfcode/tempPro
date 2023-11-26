using AutoFixture;
using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers;
using ITFCode.Core.Service.Tests.TestData;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class StringValueFilterHandler_Tests : BaseValueFilterHandlerBase_Tests<StringValueFilterHandler, StringValueFilter>
    {
        #region Facts

        [Theory, MemberData(nameof(TestData))]
        public void Handle_String_Test(int itemCount, StringFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: $"{nameof(TestSimpleClass.StringProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.StringProperty);

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.StringProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.StringProperty);
        }                                                                                                                                                                                            /

        #endregion

        #region Test Data 

        public static IEnumerable<object[]> TestData =>
            (new StringFilterMatchMode[]
            {
                StringFilterMatchMode.Equals,
                //StringFilterMatchMode.NotEquals,
                StringFilterMatchMode.Contains,
                StringFilterMatchMode.StartsWith,
                StringFilterMatchMode.EndsWith,
            })
            .SelectMany(x => (new int[] { STEP_0, STEP_1, STEP_4 }).Select(y => new object[] { y, x }))
            .ToList();

        #endregion

        #region Private Methods 

        private void ExecuteTest<TClass>(ICollection<TClass> items, string propertyName, StringFilterMatchMode matchMode, Func<TClass, string> valueGetter)
        {
            int position = items.Count / 2;

            var testValues = items.ToList();

            var value = testValues.Count > 0
                ? valueGetter(testValues.Skip(position).First())
                : _fixture.Create<string>();

            var filter = new StringValueFilter
            {
                PropertyName = propertyName,
                Value = value,
                MatchMode = matchMode
            };

            var expr = new StringValueFilterHandler(filter).Handle<TClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => CheckValueComparasion(valueGetter(x), value, matchMode));

            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => CheckValueComparasion(valueGetter(x), value, matchMode)));
        }

        private static bool CheckValueComparasion(string source, string value, StringFilterMatchMode matchMode)
            => matchMode switch
            {
                StringFilterMatchMode.Equals => source.Equals(value, StringComparison.InvariantCultureIgnoreCase),
                //StringFilterMatchMode.NotEquals => !source.Equals(value, StringComparison.InvariantCultureIgnoreCase),
                StringFilterMatchMode.StartsWith => source.StartsWith(value, StringComparison.InvariantCultureIgnoreCase),
                StringFilterMatchMode.EndsWith => source.EndsWith(value, StringComparison.InvariantCultureIgnoreCase),
                StringFilterMatchMode.Contains => source.Contains(value, StringComparison.InvariantCultureIgnoreCase),
                _ => throw new ArgumentException($"Invalid enum value for MatchMode: '{matchMode}'"),
            };

        #endregion
    }
}