﻿using System;
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
        public string GroupID { get; set; }
        public string AlprKey { get; set; }
        public string FaceKey { get; set; }
        public string FaceAPIEndpoint { get; set; }

        public AppSettings()
        {
            Configuration = this;
        }
    }
}
