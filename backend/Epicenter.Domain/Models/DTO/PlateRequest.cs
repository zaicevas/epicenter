using static Epicenter.Domain.Models.Abstract.MissingModel;

namespace Epicenter.Domain.Models.DTO
{
    public struct PlateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SearchReason? Reason { get; set; }
        public string BaseImage { get; set; }
        public string NumberPlate { get; set; }
    }
}
