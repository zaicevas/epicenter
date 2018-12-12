using System;
using Epicenter.Domain.Models.DTO;

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
