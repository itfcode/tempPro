using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.FilterHandlers;
using ITFCode.Core.Service.Tests.TestData;
using System.Linq;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class DateListFilterHandler_Tests : BaseValueFilterHandlerBase_Tests<DateListFilterHandler, DateListFilter>
    {
        [Theory]
        [InlineData(STEP_1, 1)]
        [InlineData(STEP_2, 10)]
        [InlineData(STEP_3, 100)]
        [InlineData(STEP_4, 500)]
        public void Handle_DateTime_Test(int count, int position)
        {
            var testValues = GenerateSimpleData(count);

            var getValue = (TestSimpleClass x) => x.DateTimeProperty;

            var value0 = getValue(testValues.Skip(position - 1).First());
            var value1 = getValue(testValues.Skip(position).First());
            var value2 = getValue(testValues.Skip(position + 1).First());

            var values = new List<DateTime> { value0, value1, value2 };

            var dateFilter = new DateListFilter
            {
                PropertyName = nameof(TestSimpleClass.DateTimeProperty),
                Values = values.Select(x => new DateTimeOffset(x)).ToList()
            };

            var expr = new DateListFilterHandler(dateFilter).Handle<TestSimpleClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => values.Contains(x.DateTimeProperty));
            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => values.Contains(x.DateTimeProperty)));
        }

        [Theory]
        [InlineData(STEP_1, 1)]
        [InlineData(STEP_2, 10)]
        [InlineData(STEP_3, 100)]
        [InlineData(STEP_4, 500)]
        public void Handle_DateTimeNull_Test(int count, int position)
        {
            var testValues = GenerateSimpleData(count);

            var getValue = (TestSimpleClass x) => x.DateTimeNullProperty;

            var value0 = getValue(testValues.Skip(position - 1).First());
            var value1 = getValue(testValues.Skip(position).First());
            var value2 = getValue(testValues.Skip(position + 1).First());

            var values = new List<DateTime?> { value0, value1, value2 };

            var dateFilter = new DateListFilter
            {
                PropertyName = nameof(TestSimpleClass.DateTimeNullProperty),
                Values = values.Select(x => new DateTimeOffset(x.Value)).ToList()
            };

            var expr = new DateListFilterHandler(dateFilter).Handle<TestSimpleClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => values.Contains(getValue(x)));
            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => values.Contains(getValue(x))));
        }

        [Theory]
        [InlineData(STEP_1, 1)]
        [InlineData(STEP_2, 10)]
        [InlineData(STEP_3, 100)]
        [InlineData(STEP_4, 500)]
        public void Handle_DateTimeOffset_Test(int count, int position)
        {
            var testValues = GenerateSimpleData(count);

            var getValue = (TestSimpleClass x) => x.DateTimeOffsetProperty;

            var value0 = getValue(testValues.Skip(position - 1).First());
            var value1 = getValue(testValues.Skip(position).First());
            var value2 = getValue(testValues.Skip(position + 1).First());

            var values = new List<DateTimeOffset> { value0, value1, value2 };

            var dateFilter = new DateListFilter
            {
                PropertyName = nameof(TestSimpleClass.DateTimeOffsetProperty),
                Values = values.Select(x => x).ToList()
            };

            var expr = new DateListFilterHandler(dateFilter).Handle<TestSimpleClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => values.Contains(getValue(x)));
            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => values.Contains(getValue(x))));
        }

        [Theory]
        [InlineData(STEP_1, 1)]
        [InlineData(STEP_2, 10)]
        [InlineData(STEP_3, 100)]
        [InlineData(STEP_4, 500)]
        public void Handle_DateTimeOffsetNull_Test(int count, int position)
        {
            var testValues = GenerateSimpleData(count);

            var getValue = (TestSimpleClass x) => x.DateTimeOffsetNullProperty;

            var value0 = getValue(testValues.Skip(position - 1).First());
            var value1 = getValue(testValues.Skip(position).First());
            var value2 = getValue(testValues.Skip(position + 1).First());

            var values = new List<DateTimeOffset?> { value0, value1, value2 };

            var dateFilter = new DateListFilter
            {
                PropertyName = nameof(TestSimpleClass.DateTimeOffsetNullProperty),
                Values = values.Select(x => x.Value).ToList()
            };

            var expr = new DateListFilterHandler(dateFilter).Handle<TestSimpleClass>();

            var filtered = testValues.AsQueryable()
                .Where(expr)
                .ToList();

            var expectedCount = testValues.Count(x => values.Contains(getValue(x)));
            Assert.Equal(expectedCount, filtered.Count);
            Assert.True(filtered.All(x => values.Contains(getValue(x))));
        }
    }
}