using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDCollection.Data
{
    public static class Connector
    {
        public static DbConnection GetOpenConnection(string connStringKey)
        {
            var configManager = ConfigurationManager.ConnectionStrings[connStringKey];

            var connection = DbProviderFactories
                .GetFactory(configManager.ProviderName)
                .CreateConnection();

            connection.ConnectionString = configManager.ConnectionString;
            connection.Open();

            return connection;
        }
    }
}
