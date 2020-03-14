using EzzInjector.Processors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace EzzInjector.RegisterStep
{
    internal class GetAssembliesRegisterStep : IRegisterStep
    {
        public void ApplyStep(IRegisterProcessor registerProcessor)
        {
            var assemblyPath = GetApplicationPath(AppDomain.CurrentDomain);
            var pathes = Directory.GetFiles(assemblyPath, "*.dll");

            var assemblyList = new List<Assembly>();
            foreach(var path in pathes)
            {
                var assembly = Assembly.LoadFrom(path);
                assemblyList.Add(assembly);
            }

            registerProcessor.Asseblies = new List<Assembly>(assemblyList);
        }

        private string GetApplicationPath(AppDomain domain)
        {
            if (string.IsNullOrEmpty(domain.RelativeSearchPath))
                return domain.BaseDirectory;

            return domain.RelativeSearchPath;
        }
    }
}
