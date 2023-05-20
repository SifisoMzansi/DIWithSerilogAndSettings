
// DI , Serilog , Settings 

using ConsoleUI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Extensions.Hosting;

        var builder = new ConfigurationBuilder();
        BuildConfig(builder);

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Build())
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

    
        Log.Logger.Information("Applicaiton Starting");
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddTransient<IGreetingService,GreetingService>();
                services.AddTransient<IWassupService, WassupService>();
            })
            .UseSerilog()
            .Build();


        var Sevice = ActivatorUtilities.CreateInstance<GreetingService>(host.Services);
        Sevice.Run();

        var Sevice2 = ActivatorUtilities.CreateInstance<WassupService>(host.Services);
        Sevice2.Run();

Console.ReadLine();
    
    static void BuildConfig(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.json.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables();

    }
