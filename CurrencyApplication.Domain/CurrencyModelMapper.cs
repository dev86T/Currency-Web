using CurrencyApplication.Domain.Models;

namespace CurrencyApplication.Domain;

public static class CurrencyModelMapper
{
    public static CurrencyModel Map(string from, string to, decimal rate)
    {
        return new CurrencyModel
        {
            From = from,
            To = to,
            Rate = rate,
            Source = "external-api"
        };
    }
}