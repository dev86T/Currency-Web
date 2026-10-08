namespace CurrencyApplication.Domain.Models;

public class CurrencyModel
{
    public required string From { get; set; }
    public required string To { get; set; }
    public decimal Rate { get; set; }
    public required string Source { get; set; }
}