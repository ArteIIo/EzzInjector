using EzzInjector.Contracts;
using EzzInjector.Extensions;
using EzzInjector.Processors;
using System;
using System.Linq;
using Unity;

namespace EzzInjector.RegisterStep
{
    public class RegisterDependenciesRegisterStep : IRegisterStep
    {
        public void ApplyStep(IRegisterProcessor registerProcessor)
        {
            foreach (var item in registerProcessor.Asseblies)
            {
                var typesToRegister = item.GetLoadableClassesTypes()
                    .Where(type => !type.GetInterfaces().Contains(typeof(ITypeRegister)));

                foreach (var type in typesToRegister)
                {
                    var typeInterface = type.GetInterface("I" + type.Name);
                    if (typeInterface != null)
                        registerProcessor.Container.RegisterType(typeInterface, type);
                }

                var types = item.GetLoadableClassesTypes()
                    .Where(mytype => mytype.GetInterfaces()
                        .Contains(typeof(ITypeRegister)));

                foreach (var type in types)
                {
                    var instance = (ITypeRegister)Activator.CreateInstance(type);
                    instance.RegisterDependencies(registerProcessor.Container);
                }
            }
        }
    }
}
