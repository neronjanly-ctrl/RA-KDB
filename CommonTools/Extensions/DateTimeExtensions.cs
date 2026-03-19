using System;

namespace CommonTools;

public static class DateTimeExtensions
{
    public static long UtcToUnixTimeMilliseconds(this DateTime dateTime)
    {
        return new DateTimeOffset(dateTime, TimeSpan.Zero).ToUnixTimeMilliseconds();
    }

    public static DateTimeOffset UtcToDateTimeOffset(this DateTime dateTime)
    {
        return new DateTimeOffset(dateTime, TimeSpan.Zero);
    }
}
