using EzzInjector.Processors;
using EzzInjector.RegisterStep;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;

namespace EzzInjector.Tests.RegisterStepTests
{
    public class GetAssembliesRegisterStepTests
    {
        [Fact]
        public void ApplyStep_ShouldGetAssemblies()
        {
            //Arrange
            var assemblyGetter = new GetAssembliesRegisterStep();
            var registerProcessorMock = new Mock<IRegisterProcessor>();
            var pathes = Directory.GetFiles(GetAssemblyPath(), "*.dll");
            var resultAssembly = new List<Assembly>();

            registerProcessorMock.
                SetupSet(m => m.Asseblies = It.IsAny<IEnumerable<Assembly>>())
                .Callback<IEnumerable<Assembly>>(p => resultAssembly = new List<Assembly>(p));

            //Act
            assemblyGetter.ApplyStep(registerProcessorMock.Object);

            //Assert
            Assert.Equal(
                pathes.Length,
                resultAssembly.Count);
        }

        private string GetAssemblyPath()
        {
            if (string.IsNullOrEmpty(AppDomain.CurrentDomain.RelativeSearchPath))
                return AppDomain.CurrentDomain.BaseDirectory;

            return AppDomain.CurrentDomain.RelativeSearchPath;
        }
    }
}
