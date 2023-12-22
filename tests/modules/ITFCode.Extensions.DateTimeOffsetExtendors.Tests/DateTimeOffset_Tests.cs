using ITFCode.Extensions.DateTimeOffsetExtendors.Tests.Base;

namespace ITFCode.Extensions.DateTimeOffsetExtendors.Tests
{
    public partial class DateTimeOffsetExtensions_Tests
    {
        #region Test Data 

        public static IEnumerable<object[]> TestData()
        {
            var data = new List<object[]>();

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    var offset = new Random().Next(-14, 14);
                    var hours = new Random().Next(0, 23);
                    var minutes = new Random().Next(0, 59);
                    var seconds = new Random().Next(0, 59);
                    var milliseconds = new Random().Next(0, 999);
                    var microseconds = new Random().Next(0, 999);
                    var dateTime = new DateTime(2010 + i, 1 + j, 1, hours, minutes, seconds, milliseconds, microseconds, DateTimeKind.Unspecified);
                    var date = new DateTimeOffset(dateTime, new TimeSpan(offset, 0, 0)).AddDays(new Random().Next(0, 28));
                    data.Add(new object[] { date });
                }
            }

            return data;
        }

        #endregion

        #region Private Methods 

        private void IsStartOfDay_Test(DateTimeOffset date)
        {
            Assert.Equal(0, date.Hour);
            Assert.Equal(0, date.Minute);
            Assert.Equal(0, date.Second);
            Assert.Equal(0, date.Millisecond);
            Assert.Equal(0, date.Microsecond);
        }

        private void IsEndOfDay_Test(DateTimeOffset date)
        {
            IsStartOfDay_Test(date.AddTicks(1));
        }

        private void IsStartOfMonth_Test(DateTimeOffset date)
        {
            IsStartOfDay_Test(date);
            Assert.Equal(1, date.Day);
        }

        private void IsEndOfMonth_Test(DateTimeOffset date)
        {
            IsStartOfMonth_Test(date.AddTicks(1));
        }

        #endregion
    }
}