using System.Configuration;
using System.Threading;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache.Configuration;
using Apache.Ignite.Core.Discovery.Tcp;
using Apache.Ignite.Core.Log;
using Apache.Ignite.Log4Net;
using IgniteService.Models;
using log4net;

namespace IgniteHost
{
    public class Program
    {
        private static readonly ILogger Logger = new IgniteLog4NetLogger(LogManager.GetLogger(typeof(Program)));
        private static string[] _hosts;
        private static int _backups;
        private static string _cacheName;

        static void Main(string[] args)
        {
            Logger.Info("Starting IgniteCSharp instance");
            GetAppSettings();
            StartIgniteService();
            Thread.Sleep(Timeout.Infinite);
        }

        private static void GetAppSettings()
        {
            _cacheName = ConfigurationManager.AppSettings["IgniteCacheName"];
            _hosts = ConfigurationManager.AppSettings["IgniteHosts"].Split(';');
            _backups = int.Parse(ConfigurationManager.AppSettings["IgniteBackups"]);
        }

        private static void StartIgniteService()
        {
            var serviceConf = new IgniteServiceConfiguration
            {
                IgniteConfiguration = new IgniteConfiguration
                {
                    Logger = Logger,
                    AutoGenerateIgniteInstanceName = true,
                    DiscoverySpi = new TcpDiscoverySpi
                    {
                        LocalAddress = "127.0.0.1"
                    }
                },
                CacheConfigurations = new []
                {
                    new CacheConfiguration
                    {
                        Name = _cacheName,
                        Backups = _backups,
                        CacheMode = CacheMode.Partitioned,
                        RebalanceMode = CacheRebalanceMode.Sync
                    }
                }
            };
            var service = new IgniteService.IgniteService(serviceConf);
            service.Start();
        }
    }
}
