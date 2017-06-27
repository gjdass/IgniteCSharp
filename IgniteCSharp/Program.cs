using System.Configuration;
using System.Threading;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Discovery.Tcp;
using IgniteCSharp.Services;
using IgniteCSharp.Utils;

namespace IgniteCSharp
{
    class Program
    {
        private static readonly BaseLogger _logger  = new BaseLogger("Program");

        static void Main(string[] args)
        {
            _logger.Info("Starting IgniteCSharp instance ...");
            StartIgniteService();
            Thread.Sleep(Timeout.Infinite);
        }

        private static void StartIgniteService()
        {
            var igniteConf = new IgniteConfiguration
            {
                DiscoverySpi = new TcpDiscoverySpi
                {
                    LocalAddress = ConfigurationManager.AppSettings["IgniteHost"]
                }
            };
            var service = new IgniteService(igniteConf);
            service.Start();
        }
    }
}
