using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Application.IRepositories;

namespace Application;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); ;

    }
}