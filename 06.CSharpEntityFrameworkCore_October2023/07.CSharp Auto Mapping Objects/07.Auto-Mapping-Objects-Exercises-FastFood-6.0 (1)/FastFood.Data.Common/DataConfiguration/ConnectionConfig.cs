using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Data.Common.DataConfiguration
{
    public static class ConnectionConfig
    {
        public const string ConnectionString =
            @"Server = DESKTOP-ME8RHIA; Database = FastFoodSystem; Trusted_Connection = True; TrustServerCertificate = True; MultipleActiveResultSets=true;";
    }
}
