namespace Epicenter.Domain.Services.DTO.Face.Responses
{
    public struct DetectResponse
    {
        public string FaceId { get; set; }
        public FaceAttributes FaceAttributes { get; set; }
    }

    public struct FaceAttributes
    {
        public double Smile { get; set; }
    }
}
