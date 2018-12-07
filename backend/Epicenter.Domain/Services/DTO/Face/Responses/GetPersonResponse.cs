using System.Collections.Generic;

namespace Epicenter.Domain.Services.DTO.Face.Responses
{
    public class GetPersonResponse
    {
        public string PersonId { get; set; }
        public string Name { get; set; }
        public string UserData { get; set; }
        public List<string> PersistedFaceIds { get; set; }
    }
}
