using Epicenter.Domain.Models.Abstract;

namespace Epicenter.Domain.Models
{
    public class Person : MissingModel
    {
        public string FaceAPIId { get; set; }

        public Person(string faceAPIId) => FaceAPIId = faceAPIId;

        public Person()
        {
        }
    }
}
