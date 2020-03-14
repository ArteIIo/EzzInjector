using EzzInjector.Processors;

namespace EzzInjector.Tests.EzzInjectionManagerTests
{
    public class CustomEzzBootstrapperMoq : EzzBootstrapper
    {
        public override void Startup(IRegisterProcessor registerProcessor)
        {
            registerProcessor.AddRegisterStep<CustomRegisterStep>();
        }
    }
}
