using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Attributes.Database
{
    [AttributeUsage(AttributeTargets.Property)]
    class PrimaryKeyAttribute : Attribute
    {
    }
}
