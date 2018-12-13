namespace Epicenter.Domain.Models.DTO
{
    public struct TimestampResponse
    {
        public int Id { get; set; }
        public string DateAndTime { get; set; }
        public MissingModelResponse MissingModel { get; set; }
    }
}
