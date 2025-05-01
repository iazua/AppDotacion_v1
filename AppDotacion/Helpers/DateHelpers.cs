using System;
using System.Globalization;

namespace AppDotacion.Helpers
{
    public static class DateHelpers
    {
        // Converts integer format YYYYMMDD to DateTime
        public static DateTime ConvertIntToDate(int dateInt)
        {
            string dateStr = dateInt.ToString();
            if (dateStr.Length == 8)
            {
                return DateTime.ParseExact(dateStr, "yyyyMMdd", CultureInfo.InvariantCulture);
            }
            else
            {
                return DateTime.FromOADate(dateInt); // fallback
            }
        }

        // Converts DateTime to integer format YYYYMMDD
        public static int ConvertDateToInt(DateTime date)
        {
            return int.Parse(date.ToString("yyyyMMdd"));
        }
    }
}

