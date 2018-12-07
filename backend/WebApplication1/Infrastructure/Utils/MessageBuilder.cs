using System;
using Epicenter.Application.Models.Responses;

namespace Epicenter.Application.Infrastructure.Utils
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
