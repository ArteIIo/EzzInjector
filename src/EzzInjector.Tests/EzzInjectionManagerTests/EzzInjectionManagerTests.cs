using EzzInjector.Processors;
using EzzInjector.RegisterStep;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace EzzInjector.Tests.EzzInjectionManagerTests
{
    public class EzzInjectionManagerTests
    {
        [Fact]
        public void Initialize_ShouldReturnObject()
        {
            //Act
            var injectorManager = EzzInjectionManager.Initialize();

            //Assert
            Assert.NotNull(injectorManager);
        }

        [Fact]
        public void InitializeAndBuild_WithBootstrap_ShouldReturnObject()
        {
            //Arrange
            var bootstrapperMoq = new Mock<IRegisterProcessor>();
            bootstrapperMoq.Setup(m => m.GetRegisterSteps())
                .Returns(new List<IRegisterStep> { new CustomRegisterStep() });

            var injectorManager = EzzInjectionManager
                .Initialize()
                .WithBootstrapper<CustomEzzBootstrapperMoq>();

            //Act
            injectorManager.BuildContainer(bootstrapperMoq.Object);

            //Assert
            bootstrapperMoq.Verify(m => m.AddRegisterStep<CustomRegisterStep>(), Times.Once);
        }

        [Fact]
        public void InitializeAndBuild_WithPrefix_ShouldReturnObject()
        {
            //Arrange
            const string prefix = "MyPrefix";

            var bootstrapperMoq = new Mock<IRegisterProcessor>();
            bootstrapperMoq.Setup(m => m.GetRegisterSteps())
                .Returns(new List<IRegisterStep> { new CustomRegisterStep() });

            var injectorManager = EzzInjectionManager
                .Initialize()
                .WithAssemblyPrefix(prefix)
                .WithBootstrapper<CustomEzzBootstrapperMoq>();

            //Act
            injectorManager.BuildContainer(bootstrapperMoq.Object);

            //Assert
            bootstrapperMoq.VerifySet(m => m.AssemblyPrefix = It.IsAny<string>(), Times.Once);
        }

        [Fact]
        public void Dispose_ShouldReturnNullForContainer()
        {
            //Arrange
            var injectorManager = EzzInjectionManager.Initialize();

            //Act
            injectorManager.Dispose();

            //Assert
            Assert.Null(injectorManager.Container);
        }
    }
}
