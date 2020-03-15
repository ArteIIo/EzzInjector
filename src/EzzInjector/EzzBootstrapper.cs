using EzzInjector.Processors;
using EzzInjector.RegisterStep;

namespace EzzInjector
{
    public class EzzBootstrapper
    {
        public virtual void Startup(IRegisterProcessor registerProcessor)
        {
            registerProcessor
                .AddRegisterStep<GetAssembliesRegisterStep>()
                .AddRegisterStep<FilterAssembliesRegisterStep>()
                .AddRegisterStep<RegisterDependenciesRegisterStep>();
        }

        public void Execute(IRegisterProcessor registerProcessor)
        {
            foreach (var steps in registerProcessor.GetRegisterSteps())
                steps.ApplyStep(registerProcessor);
        }
    }
}
