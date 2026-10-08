using CurrencyApplication.Domain.Models;

namespace CurrencyApplication.Service.Interfaces;

public interface ICurrencyApiClient
{
    public Task <ExternalCurrencyResponse> GetCurrenciesAsync(CancellationToken cancellationToken);
}