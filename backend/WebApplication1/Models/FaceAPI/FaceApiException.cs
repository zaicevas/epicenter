using System;

namespace WebApplication1.Models.FaceAPI
{
    public class FaceAPIException : Exception
    {
        public string Code { get; set; }

        public FaceAPIException(string code, string message) : base(message)
        {
            Code = code;
        }
    }
}
