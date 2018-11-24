using System;
using WebApplication1.Models.Abstract;

namespace WebApplication1.Models
{
    public class Timestamp : Model
    {
        public string IdentifiedEntity { get; set; }
        public int IdentifiedEntityID { get; set; }
        public string DateAndTime { get; set; }

        public Timestamp(Type identifiedEntity, int identifiedEntityID, string dateAndTime)
        {
            IdentifiedEntity = identifiedEntity.Name;
            IdentifiedEntityID = identifiedEntityID;
            DateAndTime = dateAndTime;
        }

        public Timestamp()
        {
        }
    }
}
