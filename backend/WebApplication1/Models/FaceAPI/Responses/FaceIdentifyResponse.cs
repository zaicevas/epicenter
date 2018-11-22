using System.Collections.Generic;
using WebApplication1.Models.FaceAPI;

namespace WebApplication1.Models.FaceAPI.Responses
{
    public class FaceIdentifyResponse
    {
        public string FaceId { get; set; }
        public List<FaceIdentifyCandidate> Candidates { get; set; }
    }
}
