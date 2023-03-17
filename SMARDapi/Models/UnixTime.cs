namespace SMARDapi.Models;

/// <summary>
/// Provides methods to work with Unix timestamps.
/// </summary>
internal static class UnixTime
{
    /// <summary>
    /// Converts the specified <see cref="DateTime"/> object to a Unix timestamp.
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime"/> object to convert.</param>
    /// <returns>A Unix timestamp as a long.</returns>
    public static long GetUnixTimestamp(DateTime dateTime)
    {
        var timeSpan = dateTime.ToUniversalTime() - DateTime.UnixEpoch;
        return (long)timeSpan.TotalMilliseconds;
    }

    /// <summary>
    /// Converts the specified Unix timestamp to a <see cref="DateTime"/> object.
    /// </summary>
    /// <param name="timestamp">The Unix timestamp as a long.</param>
    /// <returns>A <see cref="DateTime"/> object in the local time zone.</returns>
    public static DateTime FromUnixTimestamp(long timestamp)
    {
        return DateTime.UnixEpoch.AddMilliseconds(timestamp).ToLocalTime();
    }

    /// <summary>
    /// Gets the current Unix timestamp as a long.
    /// </summary>
    public static long Now => GetUnixTimestamp(DateTime.Now);

    /// <summary>
    /// Gets the Unix timestamp for today as a long.
    /// </summary>
    public static long Today => GetUnixTimestamp(DateTime.Today);
}
