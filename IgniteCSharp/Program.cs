using System.Configuration;
using System.Threading;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Discovery.Tcp;
using Apache.Ignite.Core.Log;
using Apache.Ignite.Log4Net;
using IgniteCSharp.Services;
using IgniteCSharp.Utils;
using log4net;
using log4net.Config;

namespace IgniteCSharp
{
    class Program
    {
        private static readonly ILogger Logger = new IgniteLog4NetLogger(LogManager.GetLogger(typeof(Program)));

        static void Main(string[] args)
        {
            Logger.Info("Starting IgniteCSharp instance");
            StartIgniteService();
            Thread.Sleep(Timeout.Infinite);
        }

        private static void StartIgniteService()
        {
            var igniteConf = new IgniteConfiguration
            {
                Logger = Logger,
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
