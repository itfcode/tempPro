using AutoFixture;
using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers;
using ITFCode.Core.Service.Tests.TestData;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class DateValueFilterHandler_Tests : BaseValueFilterHandlerBase_Tests<DateValueFilterHandler, DateValueFilter>
    {
        #region Facts

        [Theory, MemberData(nameof(TestData))]
        public void Handle_DateTime_Test(int itemCount, DateFilterMatchMode matchMode)
        {
            var simpleItems = GenerateSimpleData(itemCount);
            var simpleValue = simpleItems.Count > 0 ? new DateTimeOffset(simpleItems.First().DateTimeProperty) : _fixture.Create<DateTimeOffset>();

            ExecuteTest(
                items: simpleItems,
                propertyName: nameof(TestSimpleClass.DateTimeProperty),
                matchMode: matchMode,
                value: simpleValue,
                valueGetter: x => new DateTimeOffset(x.DateTimeProperty));

            var complexItems = GenerateComplexData(itemCount);
            var complexValue = complexItems.Count > 0 ? complexItems.First().Property1.DateTimeProperty : _fixture.Create<DateTimeOffset>();

            ExecuteTest(
                items: complexItems,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.DateTimeProperty)}",
                matchMode: matchMode,
                value: complexValue,
                valueGetter: x => new DateTimeOffset(x.Property1.DateTimeProperty));
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_DateTimeNull_Test(int itemCount, DateFilterMatchMode matchMode)
        {
            var simpleItems = GenerateSimpleData(itemCount);
            var simpleValue = simpleItems.Count > 0 ? new DateTimeOffset(simpleItems.First().DateTimeNullProperty.Value) : _fixture.Create<DateTimeOffset>();

            ExecuteTest(
                items: simpleItems,
                propertyName: nameof(TestSimpleClass.DateTimeNullProperty),
                matchMode: matchMode,
                value: simpleValue,
                valueGetter: x => new DateTimeOffset(x.DateTimeNullProperty.Value));

            var complexItems = GenerateComplexData(itemCount);
            var complexValue = complexItems.Count > 0 ? complexItems.First().Property1.DateTimeNullProperty.Value : _fixture.Create<DateTimeOffset>();

            ExecuteTest(
                items: complexItems,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.DateTimeProperty)}",
                matchMode: matchMode,
                value: complexValue,
                valueGetter: x => new DateTimeOffset(x.Property1.DateTimeProperty));
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_DateTimeOffset_Test(int itemCount, DateFilterMatchMode matchMode)
        {
            var simpleItems = GenerateSimpleData(itemCount);
            var simpleValue = simpleItems.Count > 0 ? simpleItems.First().DateTimeOffsetProperty : _fixture.Create<DateTimeOffset>();

            ExecuteTest(
                items: simpleItems,
                propertyName: nameof(TestSimpleClass.DateTimeOffsetProperty),
                matchMode: matchMode,
                value: simpleValue,
                valueGetter: x => x.DateTimeOffsetProperty);

            var complexItems = GenerateComplexData(itemCount);
            var complexValue = complexItems.Count > 0 ? complexItems.First().Property1.DateTimeOffsetProperty : _fixture.Create<DateTimeOffset>();

            ExecuteTest(
                items: complexItems,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.DateTimeOffsetProperty)}",
                matchMode: matchMode,
                value: complexValue,
                valueGetter: x => x.Property1.DateTimeOffsetProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_DateTimeOffsetNull_Test(int itemCount, DateFilterMatchMode matchMode)
        {
            var simpleItems = GenerateSimpleData(itemCount);
            var simpleValue = simpleItems.Count > 0 ? simpleItems.First().DateTimeOffsetNullProperty.Value : _fixture.Create<DateTimeOffset>();

            ExecuteTest(
                items: simpleItems,
                propertyName: nameof(TestSimpleClass.DateTimeOffsetNullProperty),
                matchMode: matchMode,
                value: simpleValue,
                valueGetter: x => x.DateTimeOffsetNullProperty.Value);

            var complexItems = GenerateComplexData(itemCount);
            var complexValue = complexItems.Count > 0 ? complexItems.First().Property1.DateTimeOffsetNullProperty.Value : _fixture.Create<DateTimeOffset>();

            ExecuteTest(
                items: complexItems,
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.DateTimeOffsetNullProperty)}",
                matchMode: matchMode,
                value: complexValue,
                valueGetter: x => x.Property1.DateTimeOffsetNullProperty.Value);
        }

        #endregion

        #region Test Data

        public static IEnumerable<object[]> TestData =>
            (new DateFilterMatchMode[]
            {
                DateFilterMatchMode.Equals,
                DateFilterMatchMode.LessThan,
                DateFilterMatchMode.LessThanOrEquals,
                DateFilterMatchMode.GreaterThan,
                DateFilterMatchMode.GreaterThanOrEquals
            })
            .SelectMany(x => (new int[] { STEP_0, STEP_1, STEP_2, STEP_4 }).Select(y => new object[] { y, x }))
            .ToList();

        #endregion

        #region Private Methods 

        private void ExecuteTest<TClass>(ICollection<TClass> items, string propertyName, DateFilterMatchMode matchMode, DateTimeOffset value, Func<TClass, DateTimeOffset> valueGetter)
        {
            var testValues = items.ToList();

            var filter = new DateValueFilter
            {
                PropertyName = propertyName,
                Value = value,
                MatchMode = matchMode
            };

            var expr = new DateValueFilterHandler(filter).Handle<TClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => CheckValueComparasion(valueGetter(x), value, matchMode));

            Assert.True(filtered.All(x => CheckValueComparasion(valueGetter(x), value, matchMode)));
            Assert.Equal(expectedCount, filtered.Count);
        }

        private static bool CheckValueComparasion(DateTimeOffset source, DateTimeOffset value, DateFilterMatchMode matchMode)
            => matchMode switch
            {
                DateFilterMatchMode.Equals => source.Equals(value),
                DateFilterMatchMode.LessThan => source.CompareTo(value) < 0,
                DateFilterMatchMode.LessThanOrEquals => source.CompareTo(value) <= 0,
                DateFilterMatchMode.GreaterThan => source.CompareTo(value) > 0,
                DateFilterMatchMode.GreaterThanOrEquals => source.CompareTo(value) >= 0,
                _ => throw new ArgumentException($"Invalid enum value for MatchMode:{matchMode}"),
            };

        #endregion
    }
}