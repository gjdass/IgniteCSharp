using System.Collections.Generic;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using IgniteCSharp.Models;
using IgniteCSharp.Utils;

namespace IgniteCSharp.Services
{
    public class IgniteService
    {
        private BaseLogger _logger = new BaseLogger("IgniteService");
        private IgniteConfiguration _igniteConfiguration;

        public IIgnite Ignite;
        public ICache<string, byte[]> Cache;

        public IgniteService(IgniteConfiguration igniteConf)
        {
            _igniteConfiguration = igniteConf;
        }

        public void Start()
        {
            _logger.Info("IgniteService starting");
            Ignite = Ignition.Start(_igniteConfiguration);
            Cache = Ignite.GetOrCreateCache<string, byte[]>("myCache");
            _logger.Info("Cache name={0} created", "myCache");

            var entity = new Entity
            {
                Name = "HoHo",
                Number = 1337,
                SubEntities = new List<SubEntity>
                {
                    new SubEntity("HoHo sunentity")
                }
            };
            Cache.Put(entity.Name, SerializationHelper.Serialize(entity));
        }
    }
}
