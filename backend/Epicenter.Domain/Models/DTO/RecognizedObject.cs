using static Epicenter.Domain.Models.Abstract.MissingModel;

namespace Epicenter.Domain.Models.DTO
{
    public struct RecognizedObject
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SearchReason Reason { get; set; }
        public ModelType Type { get; set; }
        public string Message { get; set; }
        public string LastSeen { get; set; }
        public int TimestampId { get; set; }
        public double Smile { get; set; }

        public override string ToString() => $"{Id}, {FirstName} {LastName}, {Reason}, {Type}, {Message}, {LastSeen}, {Smile}";
    }
}
