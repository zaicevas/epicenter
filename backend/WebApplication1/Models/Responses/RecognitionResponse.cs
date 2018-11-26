using System;

namespace WebApplication1.Models.Responses
{
    public struct RecognitionResponse
    {
        public string Message { get; set; }
        public bool Recognized { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}