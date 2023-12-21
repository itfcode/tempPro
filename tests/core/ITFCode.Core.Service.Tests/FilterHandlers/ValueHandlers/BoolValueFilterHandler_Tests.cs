using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers;
using ITFCode.Core.Service.Tests.TestData;
using System.Linq.Expressions;

namespace ITFCode.Core.Service.Tests.FilterHandlers.ValueHandlers
{
    public class BoolValueFilterHandler_Tests : BaseValueFilterHandlerBase_Tests<BoolValueFilterHandler, BoolValueFilter>
    {
        #region Facts

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Bool_Simple_Test(int itemCount, BoolFilterMatchMode matchMode, bool filterValue)
        {
            var propertyName = nameof(TestSimpleClass.BoolProperty);
            static bool valueGetter(TestSimpleClass x) => x.BoolProperty;
            var items = GenerateSimpleData(itemCount);

            var filter = new BoolValueFilter
            {
                PropertyName = propertyName,
                Value = filterValue,
                MatchMode = matchMode
            };

            RunTest(
                items: items,
                predicate: new BoolValueFilterHandler(filter).Handle<TestSimpleClass>(),
                filterValue: filterValue,
                matchMode: matchMode,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Bool_Complex_Test(int itemCount, BoolFilterMatchMode matchMode, bool filterValue)
        {
            var propertyName = $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.BoolProperty)}";
            static bool valueGetter(TestComplexClass x) => x.Property1.BoolProperty;
            var items = GenerateComplexData(itemCount);

            var filter = new BoolValueFilter
            {
                PropertyName = propertyName,
                Value = filterValue,
                MatchMode = matchMode
            };

            RunTest(
                items: items,
                predicate: new BoolValueFilterHandler(filter).Handle<TestComplexClass>(),
                filterValue: filterValue,
                matchMode: matchMode,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_BoolNullable_Simple_Test(int itemCount, BoolFilterMatchMode matchMode, bool filterValue)
        {
            var propertyName = nameof(TestSimpleClass.BoolNullProperty);
            static bool valueGetter(TestSimpleClass x) => x.BoolNullProperty ?? throw new ArgumentNullException();
            var items = GenerateSimpleData(itemCount);

            var filter = new BoolValueFilter
            {
                PropertyName = propertyName,
                Value = filterValue,
                MatchMode = matchMode
            };

            RunTest(
                items: items,
                predicate: new BoolValueFilterHandler(filter).Handle<TestSimpleClass>(),
                filterValue: filterValue,
                matchMode: matchMode,
                valueGetter: valueGetter);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_BoolNullable_Complex_Test(int itemCount, BoolFilterMatchMode matchMode, bool filterValue)
        {
            var propertyName = $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.BoolNullProperty)}";
            static bool valueGetter(TestComplexClass x) => x.Property1.BoolNullProperty ?? throw new ArgumentNullException();
            var items = GenerateComplexData(itemCount);

            var filter = new BoolValueFilter
            {
                PropertyName = propertyName,
                Value = filterValue,
                MatchMode = matchMode
            };

            RunTest(
                items: items,
                predicate: new BoolValueFilterHandler(filter).Handle<TestComplexClass>(),
                filterValue: filterValue,
                matchMode: matchMode,
                valueGetter: valueGetter);
        }

        #endregion

        #region Test Data

        public static IEnumerable<object[]> TestData =>
            (new BoolFilterMatchMode[]
            {
                BoolFilterMatchMode.Equals,
            })
            .SelectMany(x => (new int[] { STEP_0, STEP_1, STEP_4 }).Select(y => new object[] { y, x }))
            .SelectMany(x => (new bool[] { false, true }).Select(y => new object[] { x[0], x[1], y }))
            .ToList();

        #endregion

        #region Private Methods 

        private static void RunTest<TClass>(ICollection<TClass> items, Expression<Func<TClass, bool>> predicate, 
            BoolFilterMatchMode matchMode, bool filterValue, Func<TClass, bool> valueGetter)
        {
            var filtered = items.AsQueryable()
                .Where(predicate)
                .ToList();

            var expectedCount = items.Count(x => CheckValueComparasion(valueGetter(x), filterValue, matchMode));

            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => CheckValueComparasion(valueGetter(x), filterValue, matchMode)));
        }

        private static bool CheckValueComparasion(bool source, bool value, BoolFilterMatchMode matchMode)
            => matchMode switch
            {
                BoolFilterMatchMode.Equals => source.Equals(value),
                BoolFilterMatchMode.NotEquals => !source.Equals(value),
                _ => throw new ArgumentException($"Invalid enum value for MatchMode:{matchMode}"),
            };

        #endregion
    }
}