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
            ExecuteTest(count: itemCount, matchMode: matchMode);
        }

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

        private void ExecuteTest(int count, StringFilterMatchMode matchMode)
        {
            int position = count / 2;

            var testValues = GenerateData(count);
            var value = testValues.Count > 0 
                ? testValues.Skip(position).First().StringProperty
                : _fixture.Create<string>();

            var filter = new StringValueFilter
            {
                PropertyName = nameof(TestSimpleClass.StringProperty),
                Value = value,
                MatchMode = matchMode
            };

            var expr = new StringValueFilterHandler(filter).Handle<TestSimpleClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => CheckValueComparasion(x.StringProperty, value, matchMode));

            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => CheckValueComparasion(x.StringProperty, value, matchMode)));
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