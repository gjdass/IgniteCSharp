using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache.Configuration;

namespace IgniteService.Models
{
    public class IgniteServiceConfiguration
    {
        public IgniteConfiguration IgniteConfiguration { get; set; }
        public CacheConfiguration[] CacheConfigurations { get; set; }
    }
}