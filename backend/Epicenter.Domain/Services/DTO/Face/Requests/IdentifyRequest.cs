using System.Collections.Generic;

namespace Epicenter.Domain.Services.DTO.Face.Requests
{
    public struct IdentifyRequest
    {
        public List<string> FaceIds { get; set;}
        public string PersonGroupId { get; set; }
        public int? MaxNumOfCandidatesReturned { get; set; }
        public double? ConfidenceThreshold { get; set; }
    }
}
