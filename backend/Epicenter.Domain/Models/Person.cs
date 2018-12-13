using Epicenter.Domain.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epicenter.Domain.Models
{
    public class Person : MissingModel
    {
        public string FaceAPIId { get; set; }
        [NotMapped]
        public double Smile { get; set; }

        public Person(string faceAPIId) => FaceAPIId = faceAPIId;

        public Person()
        {
        }
    }
}
