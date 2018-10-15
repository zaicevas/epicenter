using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epicenterWin
{
    public abstract class MissingEntity : DbEntity
    {
        [CompositeKey]
        public string FirstName { get; set; }
        [CompositeKey]
        public string LastName { get; set; }

        public int Missing { get; set; } = 1;

        [UnecessaryColumnAttribute]
        public string FullName => $"{FirstName} {LastName}";
    }
}