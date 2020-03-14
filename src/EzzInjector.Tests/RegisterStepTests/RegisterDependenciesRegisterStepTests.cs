using EzzInjector.Processors;
using EzzInjector.RegisterStep;
using EzzInjector.TestAssembly;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity;
using Xunit;

namespace EzzInjector.Tests.RegisterStepTests
{
    public class RegisterDependenciesRegisterStepTests
    {
        [Fact]
        public void ApplyStep_ShouldAutoRegisterLocalClasses()
        {
            //Arrange
            var registrator = new RegisterDependenciesRegisterStep();
            var registerProcessorMock = new Mock<IRegisterProcessor>();
            var assemblyList = new List<Assembly> { Assembly.GetExecutingAssembly() };
            var container = new UnityContainer();

            registerProcessorMock
                .SetupGet(m => m.Container)
                .Returns(container);
            registerProcessorMock
                .SetupGet(m => m.Asseblies)
                .Returns(assemblyList);

            //Act
            registrator.ApplyStep(registerProcessorMock.Object);

            //Assert
            Assert.NotNull(container.Resolve<ITest>());
        }

        [Fact]
        public void ApplyStep_ShouldRegisterTypesFromOtherAssembly()
        {
            //Arrange
            var registrator = new RegisterDependenciesRegisterStep();
            var registerProcessorMock = new Mock<IRegisterProcessor>();
            var container = new UnityContainer();
            var assemblyList = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(assembly =>
                        assembly.GetName().Name.StartsWith("EzzInjector"))
                .ToList();

            registerProcessorMock
                .SetupGet(m => m.Container)
                .Returns(container);
            registerProcessorMock
                .SetupGet(m => m.Asseblies)
                .Returns(assemblyList);

            //Act
            registrator.ApplyStep(registerProcessorMock.Object);

            //Assert
            Assert.NotNull(container.Resolve<ITestOtherAssembly>());
        }

        [Fact]
        public void ApplyStep_ShouldAutoRegisterTypesFromOtherAssembly()
        {
            //Arrange
            var registrator = new RegisterDependenciesRegisterStep();
            var registerProcessorMock = new Mock<IRegisterProcessor>();
            var container = new UnityContainer();
            var assemblyList = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(assembly =>
                        assembly.GetName().Name.StartsWith("EzzInjector"))
                .ToList();

            registerProcessorMock
                .SetupGet(m => m.Container)
                .Returns(container);
            registerProcessorMock
                .SetupGet(m => m.Asseblies)
                .Returns(assemblyList);

            //Act
            registrator.ApplyStep(registerProcessorMock.Object);

            //Assert
            Assert.NotNull(container.Resolve<IAutoTestOtherAssembly>());
        }
    }

    public interface ITest
    {

    }

    public class Test : ITest
    {

    }
}
