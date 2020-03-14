using EzzInjector.Contracts;
using EzzInjector.Processors;
using System;
using System.Linq;
using Unity;

namespace EzzInjector.RegisterStep
{
    internal class RegisterDependenciesRegisterStep : IRegisterStep
    {
        public void ApplyStep(IRegisterProcessor registerProcessor)
        {
            foreach (var item in registerProcessor.Asseblies)
            {
                var typesToRegister = item.GetTypes().Where(type =>
                    type.IsClass
                    && !type.GetInterfaces().Contains(typeof(ITypeRegister)));

                foreach (var type in typesToRegister)
                {
                    var typeInterface = type.GetInterface("I" + type.Name);
                    if (typeInterface != null)
                        registerProcessor.Container.RegisterType(typeInterface, type);
                }

                var types = item.GetTypes()
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
