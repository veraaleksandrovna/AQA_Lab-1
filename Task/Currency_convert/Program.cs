using System;
using static ConsoleApp2.Constants;

namespace ConsoleApp2
{
    public class Program
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
            var tempsum = 0f;
            tempsum = InputValue(inCurr, sum, tempsum);

            tempsum = OutputValue(outCurr, tempsum);
            return tempsum;
        }

        private static float OutputValue(string outCurr, float tempsum)
        {
            switch (outCurr)
            {
                case "usd":
                    tempsum = (tempsum / USD);
                    break;
                case "eur":
                    tempsum = (tempsum / EUR);
                    break;
                case "rub":
                    tempsum = (tempsum / RUB);
                    break;
            }

            return tempsum;
        }

        private static float InputValue(string inCurr, float sum, float tempsum)
        {
            switch (inCurr)
            {
                case "usd":
                    tempsum = sum * USD;
                    break;
                case "eur":
                    tempsum = sum * EUR;
                    break;
                case "rub":
                    tempsum = sum * RUB;
                    break;
            }

            return tempsum;
        }

        private static void InputCurrencySumAndConvert()
        {
            for (int i = 0; i < Array.MaxLength; i++)
            {
                Console.WriteLine("Введите сумму, которую вы хотите конвертировать в формате 1000.1 USD :");
                var answer = Console.ReadLine();
                var answparse = answer.Split(' ');
                if (answparse.Length > 2)
                {
                    Console.WriteLine("Неправильный ввод суммы!");
                    Console.WriteLine("Пример ввода: 1000.1 USD");
                    Console.WriteLine("Проверьте правильность и повторите попытку.");
                    InputCurrencySumAndConvert();
                    return;
                }

                if (answparse[0].Contains("."))
                {
                    answparse[0] = answparse[0].Replace('.', ',');
                }

                float sum = 0f;
                if (!float.TryParse(answparse[0], out sum))
                {
                    Console.WriteLine("Ошибка ввода суммы! Повторите попытку.");
                    InputCurrencySumAndConvert();
                    return;
                }

                switch (answparse[1].ToLower())
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

                var inCurrency = answparse[1].ToLower();
                var outCurrency = ChooseCurrency();
                while (inCurrency == outCurrency)
                {
                    Console.WriteLine("Валюты совпадают повторите попытку.");
                    inCurrency = ChooseCurrency();
                }
                Console.WriteLine("{0} {1}", RoundValue(inCurrency, outCurrency, sum), outCurrency);
            }
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
