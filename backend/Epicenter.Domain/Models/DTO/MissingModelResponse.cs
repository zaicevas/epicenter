using static Epicenter.Domain.Models.Abstract.MissingModel;

namespace Epicenter.Domain.Models.DTO
{
    public struct MissingModelResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SearchReason Reason { get; set; }
        public byte[] BaseImage { get; set; }
        public ModelType Type { get; set; }
        public string Message { get; set; }
    }
}
