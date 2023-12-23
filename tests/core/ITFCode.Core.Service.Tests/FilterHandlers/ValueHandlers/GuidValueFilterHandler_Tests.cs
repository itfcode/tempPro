using AutoFixture;
using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers;
using ITFCode.Core.Service.Tests.TestData;
using System.Linq.Expressions;

namespace ITFCode.Core.Service.Tests.FilterHandlers.ValueHandlers
{
    public class GuidValueFilterHandler_Tests : BaseValueFilterHandlerBase_Tests<GuidValueFilterHandler, GuidValueFilter>
    {
        #region Facts: Guid & Guid?

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Guid_Simple_Test(int itemCount, GuidFilterMatchMode matchMode)
        {
            static Guid valueGetter(TestSimpleClass x) => x.GuidProperty;
            string propertyName = $"{nameof(TestSimpleClass.GuidProperty)}";
            var items = GenerateSimpleData(itemCount);
            var filterValue = itemCount > 0 ? valueGetter(items.First()) : _fixture.Create<Guid>();

            var filter = new GuidValueFilter
            {
                PropertyName = propertyName,
                Value = filterValue,
                MatchMode = matchMode
            };

            RunTest(
                items: items,
                predicate: new GuidValueFilterHandler(filter).Handle<TestSimpleClass>(),
                filterValue: filterValue,
                matchMode: matchMode,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Guid_Complex_Test(int itemCount, GuidFilterMatchMode matchMode)
        {
            static Guid valueGetter(TestComplexClass x) => x.PropertyA.GuidProperty;
            string propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.GuidProperty)}";
            var items = GenerateComplexData(itemCount);
            var filterValue = itemCount > 0 ? valueGetter(items.First()) : _fixture.Create<Guid>();

            var filter = new GuidValueFilter
            {
                PropertyName = propertyName,
                Value = filterValue,
                MatchMode = matchMode
            };

            RunTest(
                items: items,
                predicate: new GuidValueFilterHandler(filter).Handle<TestComplexClass>(),
                filterValue: filterValue,
                matchMode: matchMode,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_GuidNull_Simple_Test(int itemCount, GuidFilterMatchMode matchMode)
        {
            static Guid valueGetter(TestSimpleClass x) => x.GuidNullProperty ?? throw new ArgumentNullException(nameof(x.GuidNullProperty));
            string propertyName = $"{nameof(TestSimpleClass.GuidNullProperty)}";
            var items = GenerateSimpleData(itemCount);
            var filterValue = itemCount > 0 ? valueGetter(items.First()) : _fixture.Create<Guid>();

            var filter = new GuidValueFilter
            {
                PropertyName = propertyName,
                Value = filterValue,
                MatchMode = matchMode
            };

            RunTest(
                items: items,
                predicate: new GuidValueFilterHandler(filter).Handle<TestSimpleClass>(),
                filterValue: filterValue,
                matchMode: matchMode,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_GuidNull_Complex_Test(int itemCount, GuidFilterMatchMode matchMode)
        {
            static Guid valueGetter(TestComplexClass x) => x.PropertyA.GuidNullProperty ?? throw new ArgumentNullException(nameof(x.PropertyA.GuidNullProperty));
            string propertyName = $"{nameof(TestComplexClass.PropertyA)}.{nameof(TestSimpleClass.GuidNullProperty)}";
            var items = GenerateComplexData(itemCount);
            var filterValue = itemCount > 0 ? valueGetter(items.First()) : _fixture.Create<Guid>();

            var filter = new GuidValueFilter
            {
                PropertyName = propertyName,
                Value = filterValue,
                MatchMode = matchMode
            };

            RunTest(
                items: items,
                predicate: new GuidValueFilterHandler(filter).Handle<TestComplexClass>(),
                filterValue: filterValue,
                matchMode: matchMode,
                valueGetter: valueGetter);
        }

        #endregion

        #region Test Data 

        public static IEnumerable<object[]> TestData =>
            (new GuidFilterMatchMode[]
            {
                GuidFilterMatchMode.Equals,
            })
            .SelectMany(x => (new int[] { STEP_0, STEP_1, STEP_4 }).Select(y => new object[] { y, x }))
            .ToList();

        #endregion

        #region Private & Protected Methods

        private void RunTest<TClass>(ICollection<TClass> items, Expression<Func<TClass, bool>> predicate,
            Guid filterValue, GuidFilterMatchMode matchMode, Func<TClass, Guid> valueGetter) where TClass : class
        {
            var filtered = items.AsQueryable()
                .Where(predicate)
                .ToList();

            var expectedCount = items.Count(x => CheckValueComparasion(valueGetter(x), filterValue, matchMode));

            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => CheckValueComparasion(valueGetter(x), filterValue, matchMode)));
        }

        private static bool CheckValueComparasion(Guid source, Guid value, GuidFilterMatchMode matchMode)
            => matchMode switch
            {
                GuidFilterMatchMode.Equals => source.Equals(value),
                _ => throw new ArgumentException($"Invalid enum value for MatchMode:{matchMode}"),
            };

        #endregion
    }
}