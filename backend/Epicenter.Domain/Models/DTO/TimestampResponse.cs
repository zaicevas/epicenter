namespace Epicenter.Domain.Models.DTO
{
    public struct TimestampResponse
    {
        public int Id { get; set; }
        public string DateAndTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public MissingModelResponse MissingModel { get; set; }
    }
}
