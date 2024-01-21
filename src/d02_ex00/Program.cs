using d02_ex00;
using d02_ex00.Models;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Input error. Check the input data and repeat the request.");
            return;
        }

        string sumString = args[0];
        string ratesDirectory = args[1];

        if (TryParseInput(sumString, out ExchangeSum inputSum))
        {
            var exchanger = new Exchanger();
            exchanger.LoadExchangeRates(ratesDirectory);

            Console.WriteLine($"Amount in the original currency: {inputSum.Amount.ToString("N2", CultureInfo.GetCultureInfo("en-GB"))} {inputSum.CurrencyIdentifier}");

            foreach (var convertedSum in exchanger.Convert(inputSum))
            {
                Console.WriteLine($"Amount in {convertedSum.CurrencyIdentifier}: {convertedSum.Amount.ToString("N2", CultureInfo.GetCultureInfo("en-GB"))} {convertedSum.CurrencyIdentifier}");
            }
        }
        else
        {
            Console.WriteLine("Input error. Check the input data and repeat the request.");
        }
    }

    static bool TryParseInput(string input, out ExchangeSum exchangeSum)
    {
        exchangeSum = default;

        string[] parts = input.Split(' ');
        if (parts.Length == 2 && decimal.TryParse(parts[0], out decimal amount))
        {
            exchangeSum = new ExchangeSum(amount, parts[1]);
            return true;
        }

        return false;
    }
}