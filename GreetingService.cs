

// DI , Serilog , Settings 



using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class GreetingService : IGreetingService
{
    private readonly ILogger<GreetingService> _iLog;
    private readonly IConfiguration _iConfig;

 
    public GreetingService(ILogger<GreetingService> log, IConfiguration config)
    {
        _iLog = log;
        _iConfig = config;
    }

    public void Run()
    {
        for (int i = 0; i < _iConfig.GetValue<int>("LoopTimes"); i++)
        {
            _iLog.LogInformation($"Run number {i}");
            _iLog.LogInformation("Run number {runumber}", i);
        }
    }
}
