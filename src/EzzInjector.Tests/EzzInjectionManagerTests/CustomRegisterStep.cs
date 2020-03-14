using EzzInjector.Processors;
using EzzInjector.RegisterStep;
using System.Collections.Generic;
using System.Reflection;

namespace EzzInjector.Tests.EzzInjectionManagerTests
{
    public class CustomRegisterStep : IRegisterStep
    {
        public void ApplyStep(IRegisterProcessor registerProcessor)
        {
            registerProcessor.Asseblies = new List<Assembly>();
        }
    }
}
