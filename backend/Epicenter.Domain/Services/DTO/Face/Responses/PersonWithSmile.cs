using Epicenter.Domain.Models;

namespace Epicenter.Domain.Services.DTO.Face.Responses
{
    public struct PersonWithSmile
    {
        public Person Person { get; set; }
        public double Smile { get; set; }
    }
}
