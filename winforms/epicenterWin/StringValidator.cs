using System;
using System.Text.RegularExpressions;

namespace epicenterWin
{
    public static class StringValidator
    {
        private static Regex _nameRegex = new Regex(@"^[A-Z][a-z]*$");
        private static Regex _ltPlate = new Regex(@"^[A-z]{3}-?\d{3}$");

        public static bool NamePatternValid(this string str)
        {
            return _nameRegex.IsMatch(str);
        }

        public static bool NumberPlateValid(this string str)
        {
            return _ltPlate.IsMatch(str);
        }
    }
}
