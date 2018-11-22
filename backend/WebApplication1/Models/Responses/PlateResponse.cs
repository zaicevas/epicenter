using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Responses
{
    public struct PlateResponse
    {
        public bool Recognized { get; set; }
        public string Message { get; set; }
    }
}
