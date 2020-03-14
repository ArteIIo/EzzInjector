using EzzInjector.RegisterStep;
using System.Collections.Generic;
using System.Reflection;
using Unity;

namespace EzzInjector.Processors
{
    internal class RegisterProcessor : IRegisterProcessor
    {
        private readonly List<IRegisterStep> _registerSteps;
        private readonly IUnityContainer _unityContainer;

        public IUnityContainer Container => _unityContainer;

        public IEnumerable<Assembly> Asseblies { get; set; }

        public string AssemblyPrefix { get; set; }

        public RegisterProcessor(IUnityContainer unityContainer)
        {
            _registerSteps = new List<IRegisterStep>();
            _unityContainer = unityContainer;

            Asseblies = new List<Assembly>();
        }

        public IRegisterProcessor AddRegisterStep<TRegisterStep>()where TRegisterStep : IRegisterStep, new()
        {
            _registerSteps.Add(new TRegisterStep());
            return this;
        }

        public IReadOnlyCollection<IRegisterStep> GetRegisterSteps()
        {
            return _registerSteps.AsReadOnly();
        }
    }
}