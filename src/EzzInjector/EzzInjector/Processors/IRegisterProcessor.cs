using EzzInjector.RegisterStep;
using System.Collections.Generic;
using System.Reflection;
using Unity;

namespace EzzInjector.Processors
{
    public interface IRegisterProcessor
    {
        IUnityContainer Container { get; }

        IEnumerable<Assembly> Asseblies { get; set; }

        string AssemblyPrefix { get; set; }

        IRegisterProcessor AddRegisterStep<TRegisterStep>() where TRegisterStep : IRegisterStep, new();

        IReadOnlyCollection<IRegisterStep> GetRegisterSteps();
    }
}
