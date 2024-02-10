using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortedExam
{
    public static class DateTimeHelper
    {
        public static string FormatDateTime(this string datetime)
        {
            return DateTimeOffset.TryParse(datetime, out var date) ? date.ToString("yyyy-MM-dd HH:mm") : null;
        }
    }
}