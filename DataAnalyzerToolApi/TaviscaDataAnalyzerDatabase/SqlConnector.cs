using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaviscaDataAnalyzerDatabase
{
   public class SqlConnector:ISqlConnector
    {
        private SqlConnection connector;    
        private readonly AppSetting _appSettings;
        public SqlConnector(IOptions<AppSetting>appSettings)
        {
            _appSettings=appSettings.Value;
        }
        private SqlConnection Connection()
        {
            string connectionString = _appSettings.ConnectionStringSql;
            connector = new SqlConnection(connectionString);
            return connector;
        }
        public SqlConnection ConnectionEstablisher()
        {
            return Connection();
        }
    }
}
