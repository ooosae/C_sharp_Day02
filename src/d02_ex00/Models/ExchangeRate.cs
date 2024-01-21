namespace d02_ex00.Models;

public struct ExchangeRate
{
    public string FromCurrency { get; }
    public string ToCurrency { get; }
    public decimal Rate { get; }

    public ExchangeRate(string fromCurrency, string toCurrency, decimal rate)
    {
        FromCurrency = fromCurrency;
        ToCurrency = toCurrency;
        Rate = rate;
    }
}