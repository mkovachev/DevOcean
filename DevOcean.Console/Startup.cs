using Autofac;
using DevOcean.Console.IoCConfig;
using DevOcean.Engine.Interfaces;

namespace DevOcean.Console
{
    public class Startup
    {
        public static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacConfig());
            var container = builder.Build();

            var engine = container.Resolve<IEngine>();
            engine.Start();
        }
    }
}
