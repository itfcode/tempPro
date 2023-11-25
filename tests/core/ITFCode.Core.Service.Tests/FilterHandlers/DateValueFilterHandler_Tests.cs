using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers;
using ITFCode.Core.Service.Tests.TestData;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class DateValueFilterHandler_Tests : BaseValueFilterHandlerBase_Tests<DateValueFilterHandler, DateValueFilter>
    {
        [Theory]
        [InlineData(STEP_1, 1)]
        [InlineData(STEP_2, 10)]
        [InlineData(STEP_3, 100)]
        [InlineData(STEP_4, 500)]
        public void Handle_DateTime_Test(int count, int position)
        {
            DateTime getValue(TestSimpleClass x) => x.DateTimeProperty;

            var testValues = GenerateSimpleData(count);
            var value = getValue(testValues.Skip(position - 1).First());

            var dateFilter = new DateValueFilter
            {
                PropertyName = nameof(TestSimpleClass.DateTimeProperty),
                Value = value
            };

            var expr = new DateValueFilterHandler(dateFilter).Handle<TestSimpleClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => getValue(x).Equals(value));
            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => getValue(x) == value));
        }

        [Theory]
        [InlineData(STEP_1, 1)]
        [InlineData(STEP_2, 10)]
        [InlineData(STEP_3, 100)]
        [InlineData(STEP_4, 500)]
        public void Handle_DateTimeNull_Test(int count, int position)
        {
            DateTime getValue(TestSimpleClass x) => x.DateTimeNullProperty ?? throw new NullReferenceException();

            var testValues = GenerateSimpleData(count);
            var value = getValue(testValues.Skip(position - 1).First());

            var dateFilter = new DateValueFilter
            {
                PropertyName = nameof(TestSimpleClass.DateTimeNullProperty),
                Value = value
            };

            var expr = new DateValueFilterHandler(dateFilter).Handle<TestSimpleClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => getValue(x).Equals(value));
            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => getValue(x) == value));
        }

        [Theory]
        [InlineData(STEP_1, 1)]
        [InlineData(STEP_2, 10)]
        [InlineData(STEP_3, 100)]
        [InlineData(STEP_4, 500)]
        public void Handle_DateTimeOffset_Test(int count, int position)
        {
            DateTimeOffset getValue(TestSimpleClass x) => x.DateTimeOffsetProperty;

            var testValues = GenerateSimpleData(count);
            var value = getValue(testValues.Skip(position - 1).First());

            var dateFilter = new DateValueFilter
            {
                PropertyName = nameof(TestSimpleClass.DateTimeOffsetProperty),
                Value = value
            };

            var expr = new DateValueFilterHandler(dateFilter).Handle<TestSimpleClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => getValue(x).Equals(value));
            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => getValue(x) == value));
        }

        [Theory]
        [InlineData(STEP_1, 1)]
        [InlineData(STEP_2, 10)]
        [InlineData(STEP_3, 100)]
        [InlineData(STEP_4, 500)]
        public void Handle_DateTimeOffsetNull_Test(int count, int position)
        {
            DateTimeOffset getValue(TestSimpleClass x) => x.DateTimeOffsetNullProperty ?? throw new NullReferenceException();

            var testValues = GenerateSimpleData(count);
            var value = getValue(testValues.Skip(position - 1).First());

            var dateFilter = new DateValueFilter
            {
                PropertyName = nameof(TestSimpleClass.DateTimeOffsetNullProperty),
                Value = value
            };

            var expr = new DateValueFilterHandler(dateFilter).Handle<TestSimpleClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => getValue(x).Equals(value));
            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => getValue(x) == value));
        }
    }
}