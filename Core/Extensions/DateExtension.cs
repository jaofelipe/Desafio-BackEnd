namespace DesafioBackEnd.Core.Extensions
{
    public static class DateExtension
    {
        public static DateTime NormalizeDate(this DateTime value, DateTimeKind? dateTimeKind = null) => DateTime.SpecifyKind(value, dateTimeKind ?? DateTimeKind.Utc);
    }
}
