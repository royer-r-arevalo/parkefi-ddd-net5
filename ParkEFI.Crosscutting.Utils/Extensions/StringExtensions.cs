using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Crosscutting.Utils.Extensions
{
    public static class StringExtensions
    {
        public static T ToEnum<T>(this string @this)
        {
            Type enumType = typeof(T);
            return (T)Enum.Parse(enumType, @this);
        }

        public static DateTime? ToDate(this string @this)
        {
            DateTime? dateTime = null;
            if (!string.IsNullOrEmpty(@this))
            {
                dateTime = DateTime.Parse(@this);
            }
            return dateTime;
        }
    }
}
