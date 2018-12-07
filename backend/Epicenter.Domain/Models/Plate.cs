using Epicenter.Domain.Models.Abstract;
using Epicenter.Domain.Models.Attributes.Database;

namespace Epicenter.Domain.Models
{
    public class Plate : MissingModel
    {
        [PrimaryKey]
        public string NumberPlate { get; set; }

        public Plate(string numberPlate) => NumberPlate = numberPlate;

        public Plate()
        {
        }
    }
}
