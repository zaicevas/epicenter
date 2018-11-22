using System.Collections.Generic;

namespace WebApplication1.Models.FaceAPI.Responses
{
    public class PersonResponse
    {
        public string PersonId { get; set; }
        public string Name { get; set; }
        public string UserData { get; set; }
        public List<string> PersistedFaceIds { get; set; }
    }
}
