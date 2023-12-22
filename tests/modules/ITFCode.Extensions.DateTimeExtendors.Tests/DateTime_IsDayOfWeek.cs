namespace ITFCode.Extensions.DateTimeExtendors.Tests
{
    public partial class DateTime_Reset
    {
        #region Tests

        [Theory, MemberData(nameof(TestDataForReset))]
        public void IsDayOfWeek_Test(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    Assert.True(date.IsMonday());
                    break;
                case DayOfWeek.Tuesday:
                    Assert.True(date.IsTuesday());
                    break;
                case DayOfWeek.Wednesday:
                    Assert.True(date.IsWednesday());
                    break;
                case DayOfWeek.Thursday:
                    Assert.True(date.IsThursday());
                    break;
                case DayOfWeek.Friday:
                    Assert.True(date.IsFriday());
                    break;
                case DayOfWeek.Saturday:
                    Assert.True(date.IsSaturday());
                    Assert.True(date.IsWeekEnds());
                    break;
                case DayOfWeek.Sunday:
                    Assert.True(date.IsSunday());
                    Assert.True(date.IsWeekEnds());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(date));
            }
        }

        #endregion

        #region Test Data

        public static IEnumerable<object[]> TestDataForReset()
        {
            var data = new List<object[]>();

            for (int i = 0; i < 100; i++)
            {
                data.Add(new object[]
                {
                    DateTime.Now
                        .AddDays(new Random().Next(-100, 100))
                        .AddHours(new Random().Next(-100, 100))
                        .AddMinutes(new Random().Next(-100, 100))
                        .AddSeconds(new Random().Next(-100, 100))
                        .AddMilliseconds(new Random().Next(-100, 100))
                });
            }

            return data;
        }

        #endregion
    }
}