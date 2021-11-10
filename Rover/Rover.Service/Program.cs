using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rover.Engine;
using Rover.Writer;
using Rover.Reader;

namespace Rover.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<Navigatore>();
                    services.AddSingleton<IWriter,CsvWriter>();
                    services.AddSingleton<IReader, CsvReader>();
                    services.AddHostedService<Worker>();
                });
    }
}
