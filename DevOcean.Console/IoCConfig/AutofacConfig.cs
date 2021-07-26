using Autofac;
using DevOcean.Engine;
using DevOcean.Engine.Interfaces;
using DevOcean.Infrastructure.Interfaces;
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

            builder.RegisterType<InputHelper>().As<IInputHelper>().SingleInstance();
            builder.RegisterType<InputProcessor>().As<IInputProcessor>().SingleInstance();

            builder.RegisterType<SpaceEngine>().As<IEngine>().SingleInstance();

        }
    }
}
