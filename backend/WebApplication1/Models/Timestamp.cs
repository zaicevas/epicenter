using System;
using WebApplication1.Infrastructure.Attributes.Database;
using WebApplication1.Infrastructure.Extensions;
using WebApplication1.Models.Abstract;

namespace WebApplication1.Models
{
    public class Timestamp : Model
    {
        public int? PersonID { get; set; }
        public int? PlateID { get; set; }
        public string DateAndTime { get; set; }
        [NonDatabase]
        public DateTime DateTime
        {
            get
            {
                return DateAndTime.ParseToDateTime();
            }
        }

        public Timestamp(int? personID, int? plateID, string dateAndTime)
        {
            PersonID = personID;
            PlateID = plateID;
            DateAndTime = dateAndTime;
        }

        public Timestamp()
        {
        }
    }
}