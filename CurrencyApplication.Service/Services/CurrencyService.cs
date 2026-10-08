using CurrencyApplication.Domain;
using CurrencyApplication.Domain.Models;
using CurrencyApplication.Service.Interfaces;

namespace CurrencyApplication.Service.Services;

public class CurrencyService : ICurrencyService
{
    private readonly ICurrencyApiClient _currencyApiClient;

    public CurrencyService(ICurrencyApiClient currencyApiClient)
    {
        _currencyApiClient = currencyApiClient;
    }

    public async Task<CurrencyModel> GetCurrencyModel(string from, string to, CancellationToken cancellationToken)
    {
        var currencies = await _currencyApiClient
            .GetCurrenciesAsync(cancellationToken);

        if (!currencies.Data.TryGetValue(from.ToUpper(), out var fromCurrency))
        {
            throw new ArgumentException(
                $"Currency '{from}' not found");
        }

        if (!currencies.Data.TryGetValue(to.ToUpper(), out var toCurrency))
        {
            throw new ArgumentException(
                $"Currency '{to}' not found");
        }

        var rate = toCurrency.Value / fromCurrency.Value;

        return CurrencyModelMapper.Map(
            from.ToUpper(),
            to.ToUpper(),
            rate);
    }

    public async Task<CurrencyConverter> GetCurrencyConverter(string from, string to, long amount,
        CancellationToken cancellationToken)
    {
        var currency = await GetCurrencyModel(
            from,
            to,
            cancellationToken);

        return new CurrencyConverter
        {
            From = currency.From,
            To = currency.To,
            Amount = amount,
            Rate = currency.Rate,
            Result = amount * currency.Rate
        };
    }
}