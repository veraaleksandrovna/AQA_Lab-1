using System;
using static Currency.Constants;

namespace Currency
{
    public  class Program
    {
        public Constants constants = new Constants();

        private static string ChooseCurrency()
        {
            Console.WriteLine("Выберите валюту для конвертации:");
            var currency = Console.ReadLine();
            switch (currency.ToLower())
            {
                case "usd":
                case "eur":
                case "rub":
                    return currency;
                default:
                    Console.WriteLine("Ошибка ввода валюты! Повторите попытку.");
                    Console.WriteLine("Пример ввода: RUB");
                    ChooseCurrency();
                    break;
            }

            return currency;
        }

        private static float Convert(string inCurr, string outCurr, float sum)
        {
            var currencySum = 0f;
            currencySum = InputValue(inCurr, sum, currencySum);

            currencySum = OutputValue(outCurr, currencySum);
            return currencySum;
        }

        private static float OutputValue(string outCurr, float currencySum)
        {
            switch (outCurr)
            {
                case "usd":
                    currencySum = (currencySum / USD);
                    break;
                case "eur":
                    currencySum = (currencySum / EUR);
                    break;
                case "rub":
                    currencySum = (currencySum / RUB);
                    break;
            }

            return currencySum;
        }

        private static float InputValue(string inCurr, float sum, float currencySum)
        {
            switch (inCurr)
            {
                case "usd":
                    currencySum = sum * USD;
                    break;
                case "eur":
                    currencySum = sum * EUR;
                    break;
                case "rub":
                    currencySum = sum * RUB;
                    break;
            }
            return currencySum;
        }

        private static void InputCurrencySumAndConvert()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Введите сумму, которую вы хотите конвертировать в формате 1000.1 USD :");
                var readLine = Console.ReadLine();
                var splitString = readLine.Split(' ');
                if (splitString.Length > 2)
                {
                    Console.WriteLine("Неправильный ввод суммы!");
                    Console.WriteLine("Пример ввода: 1000.1 USD");
                    Console.WriteLine("Проверьте правильность и повторите попытку.");
                    InputCurrencySumAndConvert();
                    return;
                }

                if (splitString[0].Contains("."))
                {
                    splitString[0] = splitString[0].Replace('.', ',');
                }

                float sum = 0f;
                if (!float.TryParse(splitString[0], out sum))
                {
                    Console.WriteLine("Ошибка ввода суммы! Повторите попытку.");
                    InputCurrencySumAndConvert();
                    return;
                }

                switch (StringToLower(splitString))
                {
                    case "usd":
                    case "eur":
                    case "rub":
                        break;
                    default:
                        Console.WriteLine("Выбранная валюта недоступна! Повторите попытку.");
                        InputCurrencySumAndConvert();
                        break;
                }

                var inCurrency = StringToLower(splitString);
                var outCurrency = ChooseCurrency();
                while (inCurrency == outCurrency)
                {
                    Console.WriteLine("Валюты совпадают повторите попытку.");
                    inCurrency = ChooseCurrency();
                }
                Console.WriteLine("{0} {1}", RoundValue(inCurrency, outCurrency, sum), outCurrency);
            }
        }

        private static string StringToLower(string[] splitString)
        {
            return splitString[1].ToLower();
        }

        private static double RoundValue(string inCurrency, string outCurrency, float sum)
        {
            return Math.Round(Convert(inCurrency, outCurrency, sum), 2);
        }
        
        public static void Main(string[] args)
        {
            InputCurrencySumAndConvert();
        }
    }
}
