using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epicenterWin
{
    abstract class DbEntity
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Missing { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
