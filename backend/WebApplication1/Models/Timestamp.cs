using WebApplication1.Models.Abstract;

namespace WebApplication1.Models
{
    public class Timestamp : Model
    {
        public LoggableEntity IdentifiedEntity { get; set; }
        public int IdentifiedEntityID { get; set; }
        public string DateAndTime { get; set; }

        public Timestamp(LoggableEntity entity, string timestamp, int entityID)
        {
            IdentifiedEntity = entity;
            DateAndTime = timestamp;
            IdentifiedEntityID = entityID;
        }

        public Timestamp()
        {
        }

        public enum LoggableEntity : int
        {
            Person,
            Plate
        }
    }
}
