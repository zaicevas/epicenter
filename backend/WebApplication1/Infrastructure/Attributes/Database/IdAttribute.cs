using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Infrastructure.Attributes.Database
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IDAttribute : Attribute
    {
    }
}
