using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epicenterWin
{
    // Attribute for marking composite key PROPERTIES in a database.

    [AttributeUsage(AttributeTargets.Property)]
    class CompositeKeyAttribute : Attribute
    {
    }
}
