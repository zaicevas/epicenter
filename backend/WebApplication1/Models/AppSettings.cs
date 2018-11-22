using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AppSettings
    {
        public static AppSettings Configuration;

        public string ConnectionString { get; set; }
        public string PlateAPIEndpoint { get; set; }
        public string PlatePattern { get; set; }

        public AppSettings()
        {
            Configuration = this;
        }
    }
}
