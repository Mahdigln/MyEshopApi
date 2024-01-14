         using Application.PipelineBehaviors.Product;
using Application.PipelineBehaviors.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(CreateProductBehavior<,>))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(CheckInventoryBehavior<,>))
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            ;


    }
}