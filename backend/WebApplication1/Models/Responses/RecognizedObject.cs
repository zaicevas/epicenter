using System;
using WebApplication1.Infrastructure.Extensions;
using static WebApplication1.Models.Abstract.MissingModel;

namespace WebApplication1.Models.Responses
{
    public struct RecognizedObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SearchReason Reason { get; set; }
        public ModelType Type { get; set; }
        public string Message { get; set; }
        public DateTime LastSeen { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, {Reason}, {Type}, {Message}, {LastSeen.GetFormattedDateAndTime()}";
        }
    }
}