using AutoFixture;
using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers;
using ITFCode.Core.Service.Tests.TestData;
using System.Linq.Expressions;

namespace ITFCode.Core.Service.Tests.FilterHandlers.ValueHandlers
{
    public class DateValueFilterHandler_Tests : BaseValueFilterHandlerBase_Tests<DateValueFilterHandler, DateValueFilter>
    {
        #region Facts

        [Theory, MemberData(nameof(TestData))]
        public void Handle_DateTime_Simple_Test(int itemCount, DateFilterMatchMode matchMode)
        {
            static DateTimeOffset valueGetter(TestSimpleClass x) => x.DateTimeProperty;
            string propertyName = $"{nameof(TestSimpleClass.DateTimeProperty)}";
            var items = GenerateSimpleData(itemCount);
            var filterValue = itemCount > 0 ? valueGetter(items.First()) : _fixture.Create<DateTimeOffset>();

            var filter = new DateValueFilter
            {
                PropertyName = propertyName,
                Value = filterValue,
                MatchMode = matchMode
            };

            RunTest(
                items: items,
                predicate: new DateValueFilterHandler(filter).Handle<TestSimpleClass>(),
                filterValue: filterValue,
                matchMode: matchMode,
                valueGetter: valueGetter);
        }


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
            var complexValue = complexItems.Count > 0 ? complexItems.First().PropertyA.DateTimeProperty : _fixture.Create<DateTimeOffset>();

            ExecuteTest(
                items: complexItems,
                propertyName: $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.DateTimeProperty)}",
                matchMode: matchMode,
                value: complexValue,
                valueGetter: x => new DateTimeOffset(x.PropertyA.DateTimeProperty));
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
            var complexValue = complexItems.Count > 0 ? complexItems.First().PropertyA.DateTimeNullProperty.Value : _fixture.Create<DateTimeOffset>();

            ExecuteTest(
                items: complexItems,
                propertyName: $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.DateTimeProperty)}",
                matchMode: matchMode,
                value: complexValue,
                valueGetter: x => new DateTimeOffset(x.PropertyA.DateTimeProperty));
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
            var complexValue = complexItems.Count > 0 ? complexItems.First().PropertyA.DateTimeOffsetProperty : _fixture.Create<DateTimeOffset>();

            ExecuteTest(
                items: complexItems,
                propertyName: $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.DateTimeOffsetProperty)}",
                matchMode: matchMode,
                value: complexValue,
                valueGetter: x => x.PropertyA.DateTimeOffsetProperty);
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
            var complexValue = complexItems.Count > 0 ? complexItems.First().PropertyA.DateTimeOffsetNullProperty.Value : _fixture.Create<DateTimeOffset>();

            ExecuteTest(
                items: complexItems,
                propertyName: $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.DateTimeOffsetNullProperty)}",
                matchMode: matchMode,
                value: complexValue,
                valueGetter: x => x.PropertyA.DateTimeOffsetNullProperty.Value);
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

        private void RunTest<TClass>(ICollection<TClass> items, Expression<Func<TClass, bool>> predicate,
            DateTimeOffset filterValue, DateFilterMatchMode matchMode, Func<TClass, DateTimeOffset> valueGetter) where TClass : class
        {
            var filtered = items.AsQueryable()
                .Where(predicate)
                .ToList();

            var expectedCount = items.Count(x => CheckValueComparasion(valueGetter(x), filterValue, matchMode));

            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => CheckValueComparasion(valueGetter(x), filterValue, matchMode)));
        }

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