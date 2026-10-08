using CurrencyApplication.Service.Interfaces;
using CurrencyApplication.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyApplication.Service;

public static class ServiceConfiguration
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICurrencyService, CurrencyService>();

        var apiKey = configuration["ApiKey"];

        services.AddHttpClient<ICurrencyApiClient, CurrencyApiClient>(client =>
        {
            client.BaseAddress = new Uri(
                "https://api.currencyapi.com/v3/");

            client.DefaultRequestHeaders.Add(
                "apikey",
                apiKey);
        });

        return services;
    }
}