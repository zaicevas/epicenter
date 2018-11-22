using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Mappers
{
    public class Mapper
    {
        private readonly AppSettings _appSettings;

        public Mapper(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
    }
}
