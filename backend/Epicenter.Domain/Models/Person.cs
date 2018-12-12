using Epicenter.Domain.Models.Abstract;
using Newtonsoft.Json;

namespace Epicenter.Domain.Models
{
    public class Person : MissingModel
    {
        [JsonIgnore]
        public string FaceAPIId { get; set; }

        public Person(string faceAPIId) => FaceAPIId = faceAPIId;

        public Person()
        {
        }
    }
}
