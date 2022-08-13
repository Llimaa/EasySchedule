using EasySchedule.Application.Core.ErrorBag;
using EasySchedule.Application.Core.Models;
using EasySchedule.Application.Core.Specifications;
using FluentValidation;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IErrorBagHandler, ErrorBagHandler>();
        services.AddTransient<IValidator<Category>, CategorySpecifications>();
        return services;
    }
}