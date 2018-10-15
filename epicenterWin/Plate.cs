using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epicenterWin
{
    class Plate : MissingEntity
    {
        public string NumberPlate { get; set; }
        public Plate(string numberPlate)
        {
            NumberPlate = numberPlate;
        }
    }
}
