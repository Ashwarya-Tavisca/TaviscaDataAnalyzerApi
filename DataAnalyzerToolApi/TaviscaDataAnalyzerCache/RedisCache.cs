using StackExchange.Redis;
using System;

namespace TaviscaDataAnalyzerCache
{

    public class RedisCache : ICache
    {
        internal readonly IDatabase redisDatabase;
        protected readonly IRedisConnectionFactory _connectionFactory;

        public RedisCache(IRedisConnectionFactory ConnectionFactorys)
        {
            this._connectionFactory = ConnectionFactorys;
            redisDatabase = this._connectionFactory.Connection().GetDatabase();
        }

        public string Get(string key)
        {
            string value = redisDatabase.StringGet(key);
            if (string.IsNullOrEmpty(value))
                return null;
            else
                return value;
        }
       public void Add(string key, string value)
       {
            redisDatabase.StringSet(key, value, TimeSpan.FromMinutes(1));
       }
    }
}
