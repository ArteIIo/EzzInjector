using Unity;

namespace EzzInjector.Contracts
{
    public interface ITypeRegister
    {
        void RegisterDependencies(IUnityContainer container);
    }
}
