
using Epicenter.Domain.Models.Abstract;
using Epicenter.Domain.Models.Attributes.Database;

namespace Epicenter.Domain.Models
{
    public class Person : MissingModel
    {
        [PrimaryKey]
        public string FaceAPIID { get; set; }
    }
}
