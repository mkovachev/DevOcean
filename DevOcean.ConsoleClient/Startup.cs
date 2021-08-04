using DevOcean.Engine;
using DevOcean.Engine.Interfaces;
using DevOcean.Infrastructure;
using DevOcean.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace DevOcean.ConsoleClient
{
    public class Startup
    {
        private static async Task Main(string[] args)
        {

            using IHost host = CreateHostBuilder(args).Build();
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            var engine = serviceProvider.GetService<IEngine>();
            serviceProvider.GetService<IEngine>().Start();

            //host.get

            await host.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                      services.AddSingleton<IReader, ConsoleReader>()
                              .AddSingleton<IWriter, ConsoleWriter>()
                              .AddSingleton<IInputHelper, InputHelper>()
                              .AddSingleton<IInputProcessor, InputProcessor>()
                              .AddSingleton<IEngine, SpaceEngine>());
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IEngine, SpaceEngine>();
            //serviceCollection.AddInstance<IEngine>(spaceEngine);
        }
    }
}
