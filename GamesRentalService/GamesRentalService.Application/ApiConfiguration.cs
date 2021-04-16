using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesRentalService.Application
{
    public class ApiConfiguration
    {
        public ApiConfiguration(IConfiguration configuration)
        {
            this.SecretKey = configuration["SecretKey"];
        }

        public string SecretKey { get; set; }
    }
}
