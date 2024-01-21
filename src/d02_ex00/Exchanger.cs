namespace d02_ex00;

using d02_ex00.Models;

using System;
using System.Collections.Generic;
using System.IO;

public class Exchanger
{
    private List<ExchangeRate> exchangeRates = new List<ExchangeRate>();

    public void LoadExchangeRates(string ratesDirectory)
    {
        foreach (var filePath in Directory.GetFiles(ratesDirectory, "*.txt"))
        {
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            var currency = fileName.ToUpper();

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(':');
                if (parts.Length == 2 && decimal.TryParse(parts[1], out decimal rate))
                {
                    var exchangeRate = new ExchangeRate(currency, parts[0], rate);
                    exchangeRates.Add(exchangeRate);
                }
            }
        }
    }

    public IEnumerable<ExchangeSum> Convert(ExchangeSum inputSum)
    {
        foreach (var rate in exchangeRates)
        {
            if (inputSum.CurrencyIdentifier == rate.FromCurrency)
            {
                yield return new ExchangeSum(inputSum.Amount * rate.Rate, rate.ToCurrency);
            }
        }
    }
}