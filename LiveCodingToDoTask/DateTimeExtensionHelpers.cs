using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LiveCodingToDoTask
{
    public static partial class DateTimeExtensionHelpers
    {
        public static DateTime FirstDayOfWeek(this DateTime dt)
        {
            var cultureInfo = new CultureInfo("id-ID");
            cultureInfo.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
            var diff = dt.DayOfWeek - cultureInfo.DateTimeFormat.FirstDayOfWeek;

            Console.WriteLine(cultureInfo.DateTimeFormat.FirstDayOfWeek);

            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-diff).Date;
        }

        public static DateTime LastDayOfWeek(this DateTime dt)
        {
            return dt.FirstDayOfWeek().AddDays(6);
        }

    }
}
