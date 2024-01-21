namespace d02_ex00.Models;

public struct ExchangeSum
{
    public decimal Amount { get; }
    public string CurrencyIdentifier { get; }

    public ExchangeSum(decimal amount, string currencyIdentifier)
    {
        Amount = amount;
        CurrencyIdentifier = currencyIdentifier;
    }

    public override string ToString()
    {
        return $"{Amount} {CurrencyIdentifier}";
    }
}