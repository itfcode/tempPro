namespace ITFCode.Extensions.DateTimeExtendors
{
    using System;

    public static partial class DateTimeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static DateTime ResetHours(this DateTime self)
            => self.Date;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static DateTime ResetMinutes(this DateTime self)
            => self.ResetHours().AddHours(self.Hour);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static DateTime ResetSeconds(this DateTime self)
            => self.ResetMinutes().AddMinutes(self.Minute);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static DateTime ResetMilliseconds(this DateTime self)
            => self.ResetSeconds().AddSeconds(self.Second);
    }
}
