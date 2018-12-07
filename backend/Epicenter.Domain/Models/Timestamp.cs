using System;
using Epicenter.Domain.Models.Abstract;
using Epicenter.Domain.Models.Attributes.Database;
using Epicenter.Extensions;

namespace Epicenter.Domain.Models
{
    public class Timestamp : Model
    {
        public int? PersonID { get; set; }
        public int? PlateID { get; set; }
        public string DateAndTime { get; set; }
        [NonDatabase]
        public DateTime DateTime => DateAndTime.ParseToDateTime();

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