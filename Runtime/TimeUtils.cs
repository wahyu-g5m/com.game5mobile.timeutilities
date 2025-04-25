using System;

public class TimeUtils
{
    public static string FormatTime(long number)
    {
        var minute = number % 3600 / 60;
        var second = number % 60;

        return $"{CastLeadingZeroOnTime(minute)}:{CastLeadingZeroOnTime(second)}";
    }

    public static string FormatTimeSpan(TimeSpan timeSpan)
    {
        var totalSeconds = timeSpan.TotalSeconds;
        int minutes = (int)totalSeconds / 60;
        int seconds = (int)totalSeconds % 60;

        return string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }

    private static string CastLeadingZeroOnTime(long number)
    {
        if (number <= 0)
            return "00";
        else if (number < 10)
            return $"0{number}";
        return number.ToString();
    }

    public static string CustomFormatTime(ulong number)
    {
        var day = number / 86400;
        var hour = number % 86400 / 3600;
        var minute = number % 3600 / 60;
        var second = number % 60;

        if (day > 0)
        {
            return hour > 0 ? $"{day}d {hour}h" : $"{day}d";
        }

        if (hour > 0)
        {
            return minute > 0 ? $"{hour}h {minute}m" : $"{hour}h";
        }

        if (minute > 0)
        {
            return second > 0 ? $"{minute}m {second}s" : $"{minute}m";
        }

        if (second > 0)
        {
            return $"{second}s";
        }

        return "";
    }

    public static long ConvertDateTimeToUnixTimeStamp(DateTime time)
    {
        return ((DateTimeOffset)time).ToUnixTimeSeconds();
    }

    public static DateTime ConvertUnixTimeStampToDateTime(long timeStamp)
    {
        var now = DateTime.Now;
        var utcNow = DateTime.UtcNow;
        var diffTimeZoneInSeconds = (now - utcNow).TotalSeconds;
        return new DateTime(1970, 1, 1).AddSeconds(timeStamp + diffTimeZoneInSeconds);
    }
}