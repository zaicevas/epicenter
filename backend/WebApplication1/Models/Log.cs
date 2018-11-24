using WebApplication1.Models.Abstract;

namespace WebApplication1.Models
{
    public class Log : Model
    {
        public LoggableEntity IdentifiedEntity { get; set; }
        public int IdentifiedEntityID { get; set; }
        public string Timestamp { get; set; }

        public Log(LoggableEntity entity, string timestamp, int entityID)
        {
            IdentifiedEntity = entity;
            Timestamp = timestamp;
            IdentifiedEntityID = entityID;
        }

        public Log()
        {
        }

        public enum LoggableEntity : int
        {
            Person,
            Plate
        }
    }
}
