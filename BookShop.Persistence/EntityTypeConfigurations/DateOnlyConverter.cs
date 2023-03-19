
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookShop.Persistence.EntityTypeConfigurations
{
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(
            date => new DateTime(date.Year, date.Month, date.Day),
            dateTime => new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day))
        { }
    }
}
