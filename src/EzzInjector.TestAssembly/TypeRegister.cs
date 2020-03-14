using EzzInjector.Contracts;
using System;
using Unity;

namespace EzzInjector.TestAssembly
{
    public class TypeRegister : ITypeRegister
    {
        public void RegisterDependencies(IUnityContainer container)
        {
            container.RegisterType<ITestOtherAssembly, Test>();
        }
    }

    public interface ITestOtherAssembly
    {

    }

    public class Test : ITestOtherAssembly
    {

    }

    public interface IAutoTestOtherAssembly
    {

    }

    public class AutoTestOtherAssembly : IAutoTestOtherAssembly
    {

    }
}
