using WebApplication1.Infrastructure.Attributes.Database;
using WebApplication1.Models.Abstract;

namespace WebApplication1.Models
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
