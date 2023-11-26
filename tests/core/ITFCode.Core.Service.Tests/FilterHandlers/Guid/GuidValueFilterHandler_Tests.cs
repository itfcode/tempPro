using AutoFixture;
using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers;
using ITFCode.Core.Service.Tests.TestData;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class GuidValueFilterHandler_Tests : BaseValueFilterHandlerBase_Tests<GuidValueFilterHandler, GuidValueFilter>
    {
        #region Facts

        [Theory, MemberData(nameof(TestData))]
        public void Handle_Guid_Test(int itemCount, GuidFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: $"{nameof(TestSimpleClass.GuidProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.GuidProperty);

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.GuidProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.GuidProperty);
        }

        [Theory, MemberData(nameof(TestData))]
        public void Handle_GuidNull_Test(int itemCount, GuidFilterMatchMode matchMode)
        {
            ExecuteTest(
                items: GenerateSimpleData(itemCount),
                propertyName: $"{nameof(TestSimpleClass.GuidNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.GuidNullProperty ?? throw new NullReferenceException("Not defined"));

            ExecuteTest(
                items: GenerateComplexData(itemCount),
                propertyName: $"{nameof(TestComplexClass.Property1)}.{nameof(TestSimpleClass.GuidNullProperty)}",
                matchMode: matchMode,
                valueGetter: x => x.Property1.GuidNullProperty ?? throw new NullReferenceException("Not defined"));
        }

        #endregion

        #region Test Data 

        public static IEnumerable<object[]> TestData =>
            (new GuidFilterMatchMode[]
            {
                GuidFilterMatchMode.Equals,
                //GuidFilterMatchMode.NotEquals,
            })
            .SelectMany(x => (new int[] { STEP_0, STEP_1, STEP_4 }).Select(y => new object[] { y, x }))
            .ToList();

        #endregion

        #region Private & Protected Methods

        private void ExecuteTest<TClass>(ICollection<TClass> items, string propertyName, GuidFilterMatchMode matchMode, Func<TClass, Guid> valueGetter)
        {
            int position = items.Count / 2;

            var testValues = items.ToList();

            var value = testValues.Count > 0
                ? valueGetter(testValues.Skip(position).First())
                : _fixture.Create<Guid>();

            var filter = new GuidValueFilter
            {
                PropertyName = propertyName,
                Value = value,
                MatchMode = matchMode
            };

            var expr = new GuidValueFilterHandler(filter).Handle<TClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => CheckValueComparasion(valueGetter(x), value, matchMode));

            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => CheckValueComparasion(valueGetter(x), value, matchMode)));
        }

        private static bool CheckValueComparasion(Guid source, Guid value, GuidFilterMatchMode matchMode)
            => matchMode switch
            {
                GuidFilterMatchMode.Equals => source.Equals(value),
                //GuidFilterMatchMode.NotEquals => !source.Equals(value),
                _ => throw new ArgumentException($"Invalid enum value for MatchMode:{matchMode}"),
            };

        #endregion
    }
}