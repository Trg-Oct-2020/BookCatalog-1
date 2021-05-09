using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;

namespace BookCatalog.MicroService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
             .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
             .WriteTo.Console()  // Serilog will write logs to the console.
             .WriteTo.File(new RenderedCompactJsonFormatter(), "/logs/log.json")
              //.WriteTo.File(new JsonFormatter(), // Serilog will write logs to the log file
              //                                  "serilog.json",
              //                                  restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning,
              //                                  rollingInterval: RollingInterval.Day)
            .CreateLogger();  // Creates a Serilog logger instance on the static Log.Logger property    

            try
            {
                Log.Information("Starting up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }


            //CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()  // Registers the SerilogLoggerFactory and connects the Log.Logger as the sole logging provider
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
