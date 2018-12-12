namespace Epicenter.Domain.Services.DTO.Plate.Responses
{
    public class PlateAPIResult
    {
        // it has to be a class, because we update it's state (MatchesPattern)
        public string Plate { get; set; }
        public bool MatchesPattern { get; set; }        // not from cloud
        public double Confidence { get; set; }  
        public double RegionConfidence { get; set; }
    }
}
