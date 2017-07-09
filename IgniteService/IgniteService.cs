using System.Collections.Generic;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Configuration;
using Apache.Ignite.Core.Log;
using Apache.Ignite.Log4Net;
using Core.Utils;
using IgniteService.Models;
using log4net;

namespace IgniteService
{
    public class IgniteService
    {
        private readonly ILogger _logger = new IgniteLog4NetLogger(LogManager.GetLogger("IgniteService"));
        private readonly IgniteServiceConfiguration _serviceConf;

        public IIgnite Ignite;
        public Dictionary<string, ICache<string, byte[]>> Caches;

        public IgniteService(IgniteServiceConfiguration serviceConf)
        {
            _serviceConf = serviceConf;
            Caches = new Dictionary<string, ICache<string, byte[]>>();
        }

        public void Start()
        {
            _logger.Info("IgniteService starting");
            Ignite = Ignition.Start(_serviceConf.IgniteConfiguration);

            // lets start all caches we have in configuration
            foreach (var cacheConf in _serviceConf.CacheConfigurations)
            {
                Caches.Add(cacheConf.Name, Ignite.GetOrCreateCache<string, byte[]>(cacheConf));
                _logger.Info("Cache name={0} created", cacheConf.Name);
            }

            //var entity = new Entity
            //{
            //    Name = "HoHo",
            //    Number = 1337,
            //    SubEntities = new List<SubEntity>
            //    {
            //        new SubEntity("HoHo sunentity")
            //    }
            //};
            //Cache.Put(entity.Name, SerializationHelper.Serialize(entity));
        }
    }
}
