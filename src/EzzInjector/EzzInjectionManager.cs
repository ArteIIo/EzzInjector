using EzzInjector.Processors;
using Unity;

namespace EzzInjector
{
    public class EzzInjectionManager
    {
        private string _assembliesPrefix;
        private EzzBootstrapper _ezzBootstrapper;
        private IUnityContainer _container;

        private EzzInjectionManager()
        {
            _container = new UnityContainer();
        }

        public static EzzInjectionManager Initialize()
        {
            return new EzzInjectionManager();
        }

        public EzzInjectionManager WithBootstrapper<TBootstrapper>() where TBootstrapper : EzzBootstrapper, new()
        {
            _ezzBootstrapper = new TBootstrapper();
            return this;
        }

        public EzzInjectionManager WithAssemblyPrefix(string prefix)
        {
            _assembliesPrefix = prefix;
            return this;
        }

        public void BuildContainer(IRegisterProcessor registerProcessor)
        {
            if (_ezzBootstrapper == null)
                _ezzBootstrapper = new EzzBootstrapper();

            registerProcessor.AssemblyPrefix = _assembliesPrefix;

            _ezzBootstrapper.Startup(registerProcessor);
            _ezzBootstrapper.Execute(registerProcessor);
        }

        public void BuildContainer()
        {
            var registerProcessor = new RegisterProcessor(_container);
            BuildContainer(registerProcessor);
        }
    }
}
