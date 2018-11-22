namespace WebApplication1.Models.FaceAPI.Responses
{
    public class FaceDetectResponse
    {
        public string FaceId { get; set; }
        public Rectangle FaceRectangle { get; set; }
        public FaceLandmarks FaceLandmarks { get; set; }
        public FaceAttributes FaceAttributes { get; set; }
    }
}
