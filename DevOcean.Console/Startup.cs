using DevOcean.Engine;
using DevOcean.Engine.Interfaces;
using DevOcean.Infrastructure;
using DevOcean.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DevOcean.Console
{
    public class Startup
    {
        public static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<IEngine>().Start();
        }
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IWriter, ConsoleWriter>();
            serviceCollection.AddSingleton<IReader, ConsoleReader>();
            serviceCollection.AddSingleton<IGuard, Guard>();
            serviceCollection.AddScoped<IInputHelper, InputHelper>();
            serviceCollection.AddScoped<ITaxCalculator, TaxCalculator>();
            serviceCollection.AddScoped<IInputProcessor, InputProcessor>();
            serviceCollection.AddSingleton<IEngine, SpaceEngine>();
        }
    }
}
