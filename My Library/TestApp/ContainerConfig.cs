using Autofac;
using System.Reflection;

namespace My_Library
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterType<MainWindow>().AsSelf().SingleInstance();
            builder.RegisterAssemblyTypes(assembly)
            .Where(t => t.Namespace?.Contains("ViewModel") == true)
            .AsSelf()                                 // or .AsImplementedInterfaces()
            .AsImplementedInterfaces();                 // ← remove .SingleInstance() !

            builder.RegisterAssemblyTypes(assembly)
                .Where(t =>
                    t.Namespace?.Contains("Store") == true ||
                    t.Namespace?.Contains("Service") == true ||
                    t.Namespace?.Contains("Repository") == true ||
                    t.Namespace?.Contains("Modal") == true ||
                    t.Namespace?.Contains("DbContext") == true ||
                    t.Namespace?.Contains("Components") == true ||
                    t.Namespace?.Contains("Command") == true)
                .AsImplementedInterfaces()                // much cleaner
                .SingleInstance();
            return builder.Build();
        }
    }
}
