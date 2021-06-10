using System;
using Autofac;
using Autofac.Configuration;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.Extensions.Configuration;

namespace NET5ClassLibraryInterface
{
    public interface IDataCreate
    {
        Int32 GetInt();
        Double GetDouble();
    }

    public static class Class1
    {

        static IDataCreate dataCreate;
        static String executionFolder;
        static Class1()
        {
            executionFolder = Path.GetDirectoryName(typeof(Class1).Assembly.Location);
            AssemblyLoadContext.Default.Resolving += Default_Resolving;


            var config = new ConfigurationBuilder();
            config.AddJsonFile(Path.Combine(executionFolder, "config.json"));
            var module = new ConfigurationModule(config.Build());

            var builder = new ContainerBuilder();
            builder.RegisterModule(module);
            //builder.RegisterType<ImplementationN>().As<InterfaceN>();
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                dataCreate = container.Resolve<IDataCreate>();
            }
        }

        private static Assembly Default_Resolving(AssemblyLoadContext context, AssemblyName assembly)
        {
            // DISCLAIMER: NO PROMISES THIS IS SECURE. You may or may not want this strategy. It's up to
            // you to determine if allowing any assembly in the directory to be loaded is acceptable. This
            // is for demo purposes only.
            var assemblyPath = Path.Combine(executionFolder, $"{assembly.Name}.dll");
            return context.LoadFromAssemblyPath(assemblyPath);
        }

        public static Int32 GetInt()
        {
            return dataCreate.GetInt();
        }

        public static Double GetDouble()
        {
            return dataCreate.GetDouble();
        }
    }
}
