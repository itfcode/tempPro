using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers;
using ITFCode.Core.Service.Tests.TestData;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class BoolValueFilterHandlerBase_Tests : BaseValueFilterHandlerBase_Tests<BoolValueFilterHandler, BoolValueFilter>
    {
        [Theory]
        [InlineData(STEP_3, false)]
        [InlineData(STEP_4, false)]
        [InlineData(STEP_3, true)]
        [InlineData(STEP_4, true)]
        public void Handle_Test(int count, bool value)
        {
            var testValues = GenerateData(count);

            var boolFilter = new BoolValueFilter
            {
                PropertyName = nameof(TestClass.BoolProperty),
                Value = value
            };

            var expr = new BoolValueFilterHandler(boolFilter).Handle<TestClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            Assert.Equal(testValues.Count(x => x.BoolProperty.Equals(value)), filtered.Count);
        }

        [Theory]
        [InlineData(STEP_3, false)]
        [InlineData(STEP_4, false)]
        [InlineData(STEP_3, true)]
        [InlineData(STEP_4, true)]
        public void Handle_Nullable_Test(int count, bool value)
        {
            var testValues = GenerateData(count);

            var boolFilter = new BoolValueFilter
            {
                PropertyName = nameof(TestClass.BoolNullProperty),
                Value = value
            };

            var expr = new BoolValueFilterHandler(boolFilter).Handle<TestClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            Assert.Equal(testValues.Count(x => x.BoolNullProperty.Equals(value)), filtered.Count);
        }
    }
}