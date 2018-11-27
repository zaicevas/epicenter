using System;
using WebApplication1.Infrastructure.Extensions;
using Xunit;

namespace UnitTests
{
    public class ExtensionTests
    {
        [Fact]
        public void StringToDateTimeConversionTest()
        {
            string dateText = "2018-11-26 20:40:19";

            DateTime date = dateText.ParseToDateTime();
            DateTime correctDate = new DateTime(2018, 11, 26, 20, 40, 19);

            Assert.True(correctDate == date);
        }

        [Fact]
        public void DateTimeToStringConversionTest()
        {
            DateTime date = new DateTime(2018, 11, 26, 20, 40, 19);
            string dateText = date.GetFormattedDateAndTime();
            Assert.True(dateText == "2018-11-26 20:40:19");
        }
    }
}
