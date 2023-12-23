using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers;
using ITFCode.Core.Service.Tests.TestData;

namespace ITFCode.Core.Service.Tests.FilterHandlers.RangeHandlers
{
    public class DateRangeFilterHandler_Tests : BaseValueFilterHandlerBase_Tests<DateRangeFilterHandler, DateRangeFilter>
    {
        [Theory]
        [InlineData(STEP_1, 1)]
        [InlineData(STEP_2, 10)]
        [InlineData(STEP_3, 100)]
        [InlineData(STEP_4, 500)]
        public void Handle_DateTime_Test(int count, int position)
        {
            var testValues = GenerateSimpleData(count);

            var value0 = testValues.Skip(position - 1).First().DateTimeProperty;
            var value1 = testValues.Skip(position + 2).First().DateTimeProperty;

            var dateFilter = new DateRangeFilter
            {
                PropertyName = nameof(TestSimpleClass.DateTimeProperty),
                From = value0,
                To = value1
            };

            var expr = new DateRangeFilterHandler(dateFilter).Handle<TestSimpleClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => x.DateTimeProperty >= value0 && x.DateTimeProperty <= value1);

            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => x.DateTimeProperty >= value0 && x.DateTimeProperty <= value1));
        }

        [Theory]
        [InlineData(STEP_1, 1)]
        [InlineData(STEP_2, 10)]
        [InlineData(STEP_3, 100)]
        [InlineData(STEP_4, 500)]
        public void Handle_DateTimeNull_Test(int count, int position)
        {
            var testValues = GenerateSimpleData(count);

            var value0 = testValues.Skip(position - 1).First().DateTimeProperty;
            var value1 = testValues.Skip(position + 2).First().DateTimeProperty;

            var dateFilter = new DateRangeFilter
            {
                PropertyName = nameof(TestSimpleClass.DateTimeProperty),
                From = value0,
                To = value1
            };

            var expr = new DateRangeFilterHandler(dateFilter).Handle<TestSimpleClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => x.DateTimeProperty >= value0 && x.DateTimeProperty <= value1);

            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => x.DateTimeProperty >= value0 && x.DateTimeProperty <= value1));
        }

        [Theory]
        [InlineData(STEP_1, 1)]
        [InlineData(STEP_2, 10)]
        [InlineData(STEP_3, 100)]
        [InlineData(STEP_4, 500)]
        public void Handle_DateTimeOffset_Test(int count, int position)
        {
            var testValues = GenerateSimpleData(count);

            var value0 = testValues.Skip(position - 1).First().DateTimeProperty;
            var value1 = testValues.Skip(position + 2).First().DateTimeProperty;

            var dateFilter = new DateRangeFilter
            {
                PropertyName = nameof(TestSimpleClass.DateTimeProperty),
                From = value0,
                To = value1
            };

            var expr = new DateRangeFilterHandler(dateFilter).Handle<TestSimpleClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => x.DateTimeProperty >= value0 && x.DateTimeProperty <= value1);

            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => x.DateTimeProperty >= value0 && x.DateTimeProperty <= value1));
        }

        [Theory]
        [InlineData(STEP_1, 1)]
        [InlineData(STEP_2, 10)]
        [InlineData(STEP_3, 100)]
        [InlineData(STEP_4, 500)]
        public void Handle_DateTimeOffsetNull_Test(int count, int position)
        {
            var testValues = GenerateSimpleData(count);

            var value0 = testValues.Skip(position - 1).First().DateTimeProperty;
            var value1 = testValues.Skip(position + 2).First().DateTimeProperty;

            var dateFilter = new DateRangeFilter
            {
                PropertyName = nameof(TestSimpleClass.DateTimeProperty),
                From = value0,
                To = value1
            };

            var expr = new DateRangeFilterHandler(dateFilter).Handle<TestSimpleClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => x.DateTimeProperty >= value0 && x.DateTimeProperty <= value1);

            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => x.DateTimeProperty >= value0 && x.DateTimeProperty <= value1));
        }
    }
}