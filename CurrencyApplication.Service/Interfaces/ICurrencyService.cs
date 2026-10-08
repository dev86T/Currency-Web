using CurrencyApplication.Domain.Models;

namespace CurrencyApplication.Service.Interfaces;

public interface ICurrencyService
{
    Task<CurrencyModel> GetCurrencyModel(string from, string to, CancellationToken cancellationToken);
    Task<CurrencyConverter> GetCurrencyConverter(string from, string to, long amount, CancellationToken cancellationToken);
}