using System;

namespace Task1
{
    internal class Program
    {
        private static readonly float USD = 2.5712f;
 
        private static readonly float EUR = 2.9314f;
 
        private static readonly float RUB = 0.034155f;
 
        //private static readonly float BYN = 1f;
 
 
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
 
            return null;
        }
 
        private static float Convert(string inCurr,string outCurr,float sum)
        {
            float tempsum = 0f;
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

        private static void InputCurrencySumAndConvert()
        {
            Console.Clear();
            
                Console.WriteLine("Введите сумму, которую вы хотите конвертировать:");
                var answer = Console.ReadLine();
                //Console.WriteLine(answer);
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

                Console.WriteLine("{0} {1}", Math.Round(Convert(inCurrency, outCurrency, sum), 2), outCurrency);

                return;
            
        }

        public static void Main(string[] args)
        {
           
                InputCurrencySumAndConvert();
        }
    }
}
