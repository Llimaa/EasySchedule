using Microsoft.Extensions.DependencyInjection;

namespace EasySchedule.Test
{
    public static class ServiceDescriptorExtensions
    {
        public static bool Is<TService, TInstance>(this ServiceDescriptor serviceDescriptor, ServiceLifetime lifetime)
        {
            return serviceDescriptor.ServiceType == typeof(TService) &&
                serviceDescriptor.ImplementationType == typeof(TInstance) &&
                serviceDescriptor.Lifetime == lifetime;
        }
    }
}