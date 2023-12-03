﻿using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers;
using ITFCode.Core.Service.Tests.TestData;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class BoolValueFilterHandler_Tests : BaseValueFilterHandlerBase_Tests<BoolValueFilterHandler, BoolValueFilter>
    {
        #region Facts

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Test(int itemCount, BoolFilterMatchMode matchMode, bool value)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.BoolProperty),
                matchMode: matchMode,
                value: value,
                valueGetter: x => x.BoolProperty);

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.BoolProperty)}",
                matchMode: matchMode,
                value: value,
                valueGetter: x => x.Property1.BoolProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Nullable_Test(int itemCount, BoolFilterMatchMode matchMode, bool value)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: nameof(TestSimpleClass.BoolNullProperty),
                matchMode: matchMode,
                value: value,
                valueGetter: x => x.BoolNullProperty ?? throw new NullReferenceException());

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.BoolNullProperty)}",
                matchMode: matchMode,
                value: value,
                valueGetter: x => x.Property1.BoolNullProperty ?? throw new NullReferenceException());
        }

        #endregion

        #region Test Data

        public static IEnumerable<object[]> TestData =>
            (new BoolFilterMatchMode[]
            {
                BoolFilterMatchMode.Equals,
                //BoolFilterMatchMode.NotEquals,
            })
            .SelectMany(x => (new int[] { STEP_0, STEP_1, STEP_4 }).Select(y => new object[] { y, x }))
            .SelectMany(x => (new bool[] { false, true }).Select(y => new object[] { x[0], x[1], y }))
            .ToList();

        #endregion

        #region Private Methods 

        private static void ExecuteTest<TClass>(ICollection<TClass> items, string propertyName, BoolFilterMatchMode matchMode, bool value, Func<TClass, bool> valueGetter)
        {
            var testValues = items.ToList();

            var filter = new BoolValueFilter
            {
                PropertyName = propertyName,
                Value = value,
                MatchMode = matchMode
            };

            var expr = new BoolValueFilterHandler(filter).Handle<TClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => CheckValueComparasion(valueGetter(x), value, matchMode));

            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => CheckValueComparasion(valueGetter(x), value, matchMode)));
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