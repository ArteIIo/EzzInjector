using EzzInjector.Processors;
using System.Linq;

namespace EzzInjector.RegisterStep
{
    public class FilterAssembliesRegisterStep : IRegisterStep
    {
        public void ApplyStep(IRegisterProcessor registerProcessor)
        {
            if (string.IsNullOrEmpty(registerProcessor.AssemblyPrefix))
                return;

            registerProcessor.Asseblies =
                registerProcessor.Asseblies
                    .Where(assembly => assembly.GetName().Name.StartsWith(registerProcessor.AssemblyPrefix));
        }
    }
}
