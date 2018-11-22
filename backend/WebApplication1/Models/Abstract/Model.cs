using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Attributes.Database;

namespace WebApplication1.Models.Abstract
{
    public abstract class Model
    {
        [NonDatabase]
        public int Id { get; set; }
    }
}
