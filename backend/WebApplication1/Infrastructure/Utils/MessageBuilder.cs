using System;
using WebApplication1.Models.Responses;

namespace WebApplication1.Infrastructure.Utils
{
    public static class MessageBuilder
    {
        public static string BuildResponseMessage(RecognizedObject[] responses)
        {
            string message = "Found:";
            foreach (RecognizedObject response in responses)
                message += Environment.NewLine + response.ToString();
            return message;
        }

    }
}
