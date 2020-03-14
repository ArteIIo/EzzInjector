using EzzInjector.Processors;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EzzInjector.RegisterStep
{
    public class FilterAssembliesRegisterStep : IRegisterStep
    {
        public void ApplyStep(IRegisterProcessor registerProcessor)
        {
            if (string.IsNullOrEmpty(registerProcessor.AssemblyPrefix))
                return;

            var filteredList =
                registerProcessor.Asseblies
                    .Where(assembly => 
                        assembly.GetName().Name.StartsWith(registerProcessor.AssemblyPrefix));

            registerProcessor.Asseblies = new List<Assembly>(filteredList);
        }
    }
}
