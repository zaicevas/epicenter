using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Attributes.Database;
using WebApplication1.Models.Abstract;

namespace WebApplication1.Models
{
    public class Person : MissingModel
    {
        public string FaceAPIID { get; set; }
    }
}
