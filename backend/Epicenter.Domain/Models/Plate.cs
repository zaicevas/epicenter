using Epicenter.Domain.Models.Abstract;

namespace Epicenter.Domain.Models
{
    public class Plate : MissingModel
    {
        public string NumberPlate { get; set; }

        public Plate(string numberPlate) => NumberPlate = numberPlate;

        public Plate()
        {
        }
    }
}
