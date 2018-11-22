using System.Collections.Generic;

namespace WebApplication1.Models.FaceAPI.Responses
{
    public class FaceIdentifyResponse
    {
        public string FaceId { get; set; }
        public List<Candidate> Candidates { get; set; }
    }
}
