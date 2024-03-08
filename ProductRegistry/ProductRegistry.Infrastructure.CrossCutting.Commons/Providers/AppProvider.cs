using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRegistry.Infrastructure.CrossCutting.Commons.Providers
{
    public static class AppProvider
    {
        public const string Name = "product_registry";
        public const string HealthResource = "/health";
        public const string Version = "1.0.0";
    }
}
