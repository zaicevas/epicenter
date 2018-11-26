using System.Collections.Generic;

namespace WebApplication1.Models.FaceAPI.Requests
{
    public class FaceIdentifyRequest
    {
        public List<string> FaceIds { get; set;}
        public string PersonGroupId { get; set; }
        public int? MaxNumOfCandidatesReturned { get; set; }
        public double? ConfidenceThreshold { get; set; }
    }
}
