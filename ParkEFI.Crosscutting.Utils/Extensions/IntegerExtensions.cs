using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Crosscutting.Utils.Extensions
{
    public static class IntegerExtensions
    {
        public static bool ToBoolean(this int @this)
        {
            return @this switch
            {
                0 => false,
                1 => true,
                _ => throw new InvalidOperationException("Integer value is not valid"),
            };
        }
    }
}
