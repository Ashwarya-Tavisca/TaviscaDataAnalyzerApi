using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using TaviscaDataAnalyzerDatabase;
using Microsoft.Extensions.Options;

namespace TaviscaDataAnalyzerCache
{
    public class RedisConnectionFactory : IRedisConnectionFactory
    {
        private readonly Lazy<ConnectionMultiplexer> _connection;
        private readonly AppSetting _appSettings;
        public RedisConnectionFactory(IOptions<AppSetting> appSettings)
        {
            _appSettings = appSettings.Value;
            this._connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(_appSettings.ConnectionStringRedis));
        }
        public ConnectionMultiplexer Connection()
        {
            return this._connection.Value;
        }
    }
}
