namespace CurrencyApplication.Domain.Models;

public class CurrencyConverter
{
    public required string From  { get; set; }
    public required string To { get; set; }
    public long Amount { get; set; }
    public decimal Rate { get; set; }
    public decimal Result { get; set; }
}