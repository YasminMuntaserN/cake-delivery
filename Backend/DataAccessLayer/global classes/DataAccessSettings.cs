using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer
{
    static class DataAccessSettings
    {
        private static IConfigurationRoot? _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        public static string? ConnectionString = _configuration.GetSection("ConnectionString").Value;
    }
}
