using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplication1.Infrastructure.Utils
{
    public static class RegexMatcher
    {
        private static Regex _ltPlate = new Regex(@"^[A-z]{3}-?\d{3}$");

        public static bool NumberPlateValid(this string str)
        {
            return _ltPlate.IsMatch(str);
        }
    }
}
