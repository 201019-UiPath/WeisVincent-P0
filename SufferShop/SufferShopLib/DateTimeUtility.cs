using System;

namespace SufferShopLib
{
    public static class DateTimeUtility
    {
        static readonly DateTime EpochTime1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static double GetUnixEpochAsDouble(this DateTime dateTime)
        {
            var unixTime = dateTime.ToUniversalTime() - EpochTime1970;

            return unixTime.TotalSeconds;
        }

        public static DateTime GetDateTimeFromUnixEpochAsDouble(this double dateTimeAsDoublePOSIX)
        {

            DateTime convertedTime = (EpochTime1970 + TimeSpan.FromSeconds(dateTimeAsDoublePOSIX));


            return convertedTime;
        }

        public static long GetUnixEpochAsTicks(this DateTime dateTime)
        {
            var unixTime = dateTime.ToUniversalTime() - EpochTime1970;

            return unixTime.Ticks;
        }

    }
}
