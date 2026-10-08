namespace CurrencyApplication.Domain.Models;

public class ExternalCurrencyResponse
{
    public required CurrencyMeta Meta { get; set; }
    public required Dictionary<string, ExternalCurrencyDto> Data { get; set; }
}

public class CurrencyMeta
{
    public DateTime LastUpdatedAt { get; set; }
}

public class ExternalCurrencyDto
{
    public required string Code { get; set; }
    public decimal Value { get; set; }
}