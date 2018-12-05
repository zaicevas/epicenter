namespace WebApplication1.DTO.Plate.Responses
{
    public struct PlateAPIResult
    {
        public string Plate { get; set; }
        public bool MatchesPattern { get; set; }        // not from cloud
        public double Confidence { get; set; }  
        public double RegionConfidence { get; set; }
    }
}
