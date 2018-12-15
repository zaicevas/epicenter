using static Epicenter.Domain.Models.Abstract.MissingModel;

namespace Epicenter.Domain.Models.DTO
{
    public struct PersonRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SearchReason? Reason { get; set; }
        public int? BaseImage { get; set; }
        public string[] TrainingImages { get; set; }
    }
}
