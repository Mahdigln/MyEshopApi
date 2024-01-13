using Application.IRepositories;
using Infrastructure.Authentication;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        return services

            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<ICategoryRepository, CategoryRepository>()
            .AddScoped<IAddressRepository, AddressRepository>()
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IOrderItemRepository, OrderItemRepository>()
            .AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IJwtTokenGenerator, JwtTokenGenerator>()
            .AddScoped<IDateTimeProvider, DateTimeProvider>()
            //.AddScoped<IPaymentRepository, PaymentRepository>()
            //.AddTransient<IProductRepository,CachingProductRepository>()
            .AddMemoryCache()
            .AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

    }
    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSetting = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSetting);
        services.AddSingleton(Options.Create(jwtSetting));

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSetting.Isuuer,
                    ValidAudience = jwtSetting.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSetting.Secret))
                };
                options.SaveToken = true;
            });
        return services;

    }
}