using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epicenterWin
{
    public class Person : MissingEntity
    {
        public string YML { get; set; }
        public Person(String FirstName, String LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
    }
}