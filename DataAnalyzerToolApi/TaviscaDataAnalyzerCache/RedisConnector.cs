using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace TaviscaDataAnalyzerCache
{
    public class RedisConnectionFactory : IRedisConnectionFactory
    {

        private readonly Lazy<ConnectionMultiplexer> _connection;

        public RedisConnectionFactory()
        {
            this._connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect("13.232.45.55:6379"));
        }

        public ConnectionMultiplexer Connection()
        {
            return this._connection.Value;
        }
    }
}
