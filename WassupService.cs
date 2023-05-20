using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class WassupService : IWassupService
    {
        private readonly ILogger<WassupService> _iLogger;
        private readonly IConfiguration _iConfig;

        public WassupService(ILogger<WassupService> logger, IConfiguration config)
        {
            _iLogger = logger;
            _iConfig = config;
        }

        public void Run()
        {
            for (int count = 0; count < _iConfig.GetValue<int>("WassupLoopTimes"); count++)
            {
                _iLogger.LogInformation("WassupLoopTimes {logcount} ", count);
            }
        }
    }
}
