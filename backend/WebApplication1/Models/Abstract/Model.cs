using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Infrastructure.Attributes.Database;

namespace WebApplication1.Models.Abstract
{
    public abstract class Model
    {
        [NonDatabase]
        [ID]
        public int ID { get; set; }
    }
}
