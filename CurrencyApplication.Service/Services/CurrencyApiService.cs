using System.Net.Http.Json;
using CurrencyApplication.Domain.Models;
using CurrencyApplication.Service.Interfaces;

namespace CurrencyApplication.Service.Services;

public class CurrencyApiClient : ICurrencyApiClient
{
    private readonly HttpClient _httpClient;

    public CurrencyApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ExternalCurrencyResponse> GetCurrenciesAsync(CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync(
            "latest",
            cancellationToken);

        response.EnsureSuccessStatusCode();

        var result = await response.Content
            .ReadFromJsonAsync<ExternalCurrencyResponse>(
                cancellationToken);

        return result ?? throw new InvalidOperationException(
            "Currency API returned empty response");
    }
}