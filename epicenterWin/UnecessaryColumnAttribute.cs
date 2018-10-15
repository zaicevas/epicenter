using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epicenterWin
{
    // Attribute for marking PROPERTIES which are not part of database OR are database's metadata (e.g. ID)

    [AttributeUsage(AttributeTargets.Property)]
    class UnecessaryColumnAttribute : Attribute
    {
    }
}
