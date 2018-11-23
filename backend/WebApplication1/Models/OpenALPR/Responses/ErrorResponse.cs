using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.OpenALPR.Responses
{
    public struct ErrorResponse
    {
        public string Error { get; set; }
        public string ErrorCode { get; set; }      // sorry, Microsoft
    }
}
