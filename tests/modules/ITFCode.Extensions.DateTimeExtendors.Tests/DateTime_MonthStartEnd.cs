using Shouldly;

namespace ITFCode.Extensions.DateTimeExtendors.Tests
{
    public partial class DateTime_Reset
    {
        #region Tests: MonthStart

        [Theory, MemberData(nameof(TestDataForMonthStartEnd))]
        public void MonthStartAt_Test(DateTime sourceDate)
        {
            for (var i = -5; i < 5; i++)
            {
                var targetDate = sourceDate.MonthStartAt(i);

                Assert.NotEqual(sourceDate.AddMonths(i), targetDate);
                Assert.Equal(sourceDate.AddMonths(i).Year, targetDate.Year);
                Assert.Equal(sourceDate.AddMonths(i).Month, targetDate.Month);

                IsStartOfMonth_Test(targetDate);
            }
        }

        [Theory, MemberData(nameof(TestDataForMonthStartEnd))]
        public void MonthStart_Test(DateTime sourceDate)
        {
            var targetDate = sourceDate.MonthStart();

            Assert.NotEqual(sourceDate, targetDate);
            Assert.Equal(sourceDate.Year, targetDate.Year);
            Assert.Equal(sourceDate.Month, targetDate.Month);

            IsStartOfMonth_Test(targetDate);
        }

        [Theory, MemberData(nameof(TestDataForMonthStartEnd))]
        public void MonthStartPrev_Test(DateTime sourceDate)
        {
            var targetDate = sourceDate.MonthStartPrev();

            Assert.NotEqual(sourceDate.AddMonths(-1), targetDate);
            Assert.Equal(sourceDate.AddMonths(-1).Year, targetDate.Year);
            Assert.Equal(sourceDate.AddMonths(-1).Month, targetDate.Month);

            IsStartOfMonth_Test(targetDate);
        }

        [Theory, MemberData(nameof(TestDataForMonthStartEnd))]
        public void MonthStartNext_Test(DateTime sourceDate)
        {
            var targetDate = sourceDate.MonthStartNext();

            Assert.NotEqual(sourceDate.AddMonths(1), targetDate);
            Assert.Equal(sourceDate.AddMonths(1).Year, targetDate.Year);
            Assert.Equal(sourceDate.AddMonths(1).Month, targetDate.Month);

            IsStartOfMonth_Test(targetDate);
        }

        #endregion

        #region Tests: MonthEnd

        [Theory, MemberData(nameof(TestDataForMonthStartEnd))]
        public void MonthEndAt_Test(DateTime sourceDate)
        {
            for (var i = 0; i < 10; i++)
            {
                var at = new Random().Next(-10, 10);
                var targetDate = sourceDate.MonthEndAt(at);

                var modifiedDate = sourceDate.AddMonths(at);

                Assert.Equal(modifiedDate.Year, targetDate.Year);
                Assert.Equal(modifiedDate.Month, targetDate.Month);

                Assert.Equal(1, targetDate.AddDays(1).Day);
                Assert.Equal(23, targetDate.Hour);
                Assert.Equal(59, targetDate.Minute);
                Assert.Equal(59, targetDate.Second);
            }
        }

        [Theory, MemberData(nameof(TestDataForMonthStartEnd))]
        public void MonthEnd_Test(DateTime sourceDate)
        {
            var targetDate = sourceDate.MonthEnd();

            var modifiedDate = sourceDate.AddMonths(0);

            Assert.Equal(modifiedDate.Year, targetDate.Year);
            Assert.Equal(modifiedDate.Month, targetDate.Month);

            Assert.Equal(1, targetDate.AddDays(1).Day);
            Assert.Equal(23, targetDate.Hour);
            Assert.Equal(59, targetDate.Minute);
            Assert.Equal(59, targetDate.Second);
        }

        [Theory, MemberData(nameof(TestDataForMonthStartEnd))]
        public void MonthEndPrev_Test(DateTime sourceDate)
        {
            var targetDate = sourceDate.MonthEndPrev();
            var modifiedDate = sourceDate.AddMonths(-1);

            targetDate.Year.ShouldBe(modifiedDate.Year);
            targetDate.Month.ShouldBe(modifiedDate.Month);

            targetDate.AddDays(1).Day.ShouldBe(1);

            targetDate.Hour.ShouldBe(23);
            targetDate.Minute.ShouldBe(59);
            targetDate.Second.ShouldBe(59);
        }

        [Theory, MemberData(nameof(TestDataForMonthStartEnd))]
        public void MonthEndNext_Test(DateTime sourceDate)
        {
            var targetDate = sourceDate.MonthEndNext();

            var modifiedDate = sourceDate.AddMonths(1);

            Assert.Equal(modifiedDate.Year, targetDate.Year);
            Assert.Equal(modifiedDate.Month, targetDate.Month);

            Assert.Equal(1, targetDate.AddDays(1).Day);
            Assert.Equal(23, targetDate.Hour);
            Assert.Equal(59, targetDate.Minute);
            Assert.Equal(59, targetDate.Second);
        }

        #endregion

        #region Tests Data

        public static IEnumerable<object[]> TestDataForMonthStartEnd()
        {
            var now = DateTime.Now;
            //var start = new DateTime(now.Year, now.Month, 1);

            var data = new List<object[]>();

            for (int i = 0; i < 10; i++)
            {
                data.Add(new object[]
                {
                    now.AddMonths(new Random().Next(-100, 100))
                });
            }

            return data;
        }

        #endregion

        #region Private Methods 
        private void IsStartOfDay_Test(DateTime sourceDate) 
        {
            Assert.Equal(0, sourceDate.Hour);
            Assert.Equal(0, sourceDate.Minute);
            Assert.Equal(0, sourceDate.Second);
            Assert.Equal(0, sourceDate.Millisecond);
            Assert.Equal(0, sourceDate.Microsecond);
        }

        private void IsEndOfDay_Test(DateTime sourceDate)
        {
            IsStartOfDay_Test(sourceDate.AddTicks(1));
        }

        private void IsStartOfMonth_Test(DateTime sourceDate) 
        {
            IsStartOfDay_Test(sourceDate);
            Assert.Equal(1, sourceDate.Day);
        }

        private void IsEndOfMonth_Test(DateTime sourceDate)
        {
            IsStartOfMonth_Test(sourceDate.AddTicks(1));
        }

        #endregion
    }
}