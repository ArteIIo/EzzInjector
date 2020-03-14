using EzzInjector.Processors;
using EzzInjector.RegisterStep;
using Moq;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace EzzInjector.Tests.RegisterStepTests
{
    public class FilterAssembliesRegisterStepTests
    {
        [Fact]
        public void ApplyStep_ShouldGetEmptyAssemblyList()
        {
            //Assert
            var assemblyList = AppDomain.CurrentDomain.GetAssemblies();
            var assemblyFilter = new FilterAssembliesRegisterStep();
            var registerProcessorMock = new Mock<IRegisterProcessor>();

            registerProcessorMock.SetupGet(m => m.Asseblies)
                .Returns(assemblyList);
            registerProcessorMock.Setup(m => m.AssemblyPrefix)
                .Returns("WrongPrefix");

            //Act
            assemblyFilter.ApplyStep(registerProcessorMock.Object);

            //Assert
            registerProcessorMock.VerifySet(m => 
                m.Asseblies = Enumerable.Empty<Assembly>(), Times.Once);
        }

        [Fact]
        public void ApplyStep_ShouldGetFilteredAssemblies()
        {
            //Assert
            var assemblyList = AppDomain.CurrentDomain.GetAssemblies();
            var resultAssemblyList = assemblyList.Where(assembly =>
                        assembly.GetName().Name.StartsWith("EzzInjector"));

            var assemblyFilter = new FilterAssembliesRegisterStep();
            var registerProcessorMock = new Mock<IRegisterProcessor>();

            registerProcessorMock.SetupGet(m => m.Asseblies)
                .Returns(assemblyList);
            registerProcessorMock.Setup(m => m.AssemblyPrefix)
                .Returns("EzzInjector");

            //Act
            assemblyFilter.ApplyStep(registerProcessorMock.Object);

            //Assert
            registerProcessorMock.VerifySet(m =>
                m.Asseblies = resultAssemblyList, Times.Once);
        }
    }
}
