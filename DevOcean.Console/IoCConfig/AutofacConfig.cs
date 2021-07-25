using Autofac;
using DevOcean.Engine;
using DevOcean.Engine.Interfaces;
using System.Reflection;

namespace DevOcean.Console.IoCConfig
{
    public sealed class AutofacConfig : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var currentAssembly = Assembly.Load("DevOcean");

            builder.RegisterAssemblyTypes(currentAssembly)
                   .AsImplementedInterfaces();

            builder.RegisterType<InputProcessorHelper>().As<IInputProcessorHelper>().SingleInstance();
            builder.RegisterType<InputProcessor>().As<IInputProcessor>().SingleInstance();

            builder.RegisterType<SpaceEngine>().As<IEngine>().SingleInstance();

        }
    }
}
