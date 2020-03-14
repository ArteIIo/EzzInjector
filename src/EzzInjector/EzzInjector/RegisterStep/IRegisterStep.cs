using EzzInjector.Processors;

namespace EzzInjector.RegisterStep
{
    public interface IRegisterStep
    {
        void ApplyStep(IRegisterProcessor registerProcessor);
    }
}
