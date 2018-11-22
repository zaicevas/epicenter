using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Response
{
    public class PlateResults
    {
        public string Plate { get; set; }
        public int Confidence { get; set; }
        public int RegionConfidence { get; set; }
    }
}
