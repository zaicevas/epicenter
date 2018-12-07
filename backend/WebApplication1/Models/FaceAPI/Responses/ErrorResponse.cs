namespace WebApplication1.Models.FaceAPI.Responses
{
    public struct ErrorResponse
    {
        public Error Error { get; set; }
    }

    public struct Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
