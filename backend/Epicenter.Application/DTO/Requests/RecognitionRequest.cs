using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epicenter.Application.DTO.Requests
{
    public class RecognitionRequest
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ImageBase64 { get; set; }
        public bool FoundPlate { get; set; }
        public bool FoundFace { get; set; }
    }
}
