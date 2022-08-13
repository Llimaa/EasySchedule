using EasySchedule.Application.Core.ErrorBag;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;


namespace EasySchedule.Test.Application;

public class DependencyInjectionTests
{
    [Fact]
    public void It_Should_Inject_ErrorBagHandler_As_Transient()
    {
        // Given
        var mockedServiceCollection = new Mock<IServiceCollection>();

        // When
        mockedServiceCollection.Object.AddApplication();

        mockedServiceCollection.Verify(_ => _.Add(It.Is<ServiceDescriptor>(descriptor =>
           descriptor.Is<IErrorBagHandler, ErrorBagHandler>(ServiceLifetime.Scoped))));
    }
}