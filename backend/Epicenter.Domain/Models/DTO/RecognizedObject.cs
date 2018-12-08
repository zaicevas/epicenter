using static Epicenter.Domain.Models.Abstract.MissingModel;

namespace Epicenter.Domain.Models.DTO
{
    public struct RecognizedObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SearchReason Reason { get; set; }
        public ModelType Type { get; set; }
        public string Message { get; set; }
        public string LastSeen { get; set; }

        public override string ToString() => $"{FirstName} {LastName}, {Reason}, {Type}, {Message}, {LastSeen}";
    }
}
