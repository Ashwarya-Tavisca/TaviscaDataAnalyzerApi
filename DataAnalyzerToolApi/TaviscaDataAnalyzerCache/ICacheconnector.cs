using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaviscaDataAnalyzerCache
{
    public interface ICacheconnector
    {
        ConnectionMultiplexer Connection();
    }
}
