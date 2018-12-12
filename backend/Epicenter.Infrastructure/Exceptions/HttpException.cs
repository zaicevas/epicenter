using System;

namespace Epicenter.Infrastructure.Exceptions
{
    public class HttpException : Exception
    {
        public string Code { get; set; }

        public HttpException(string code, string message) : base(message)
        {
            Code = code;
        }
    }
}
