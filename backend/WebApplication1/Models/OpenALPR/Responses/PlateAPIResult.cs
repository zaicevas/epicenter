using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.OpenALPR.Responses
{
    public class PlateAPIResult
    {
        public string Plate { get; set; }
        public bool MatchesPattern { get; set; }        // not from cloud
        public double Confidence { get; set; }  
        public double RegionConfidence { get; set; }
    }
}
