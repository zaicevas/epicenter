using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epicenterWin
{
    class Person
    {
        public int ID { get; set; }
        public int FaceID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Lost { get; set; }                                       // sqlite has no boolean data type

        public string FullName => $"{FirstName} {LastName}";                // expression body definition
    }
}
