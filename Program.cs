using System;
using System.Text.RegularExpressions;

namespace LabWork
{
        class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Лабораторна робота: Регулярні вирази");
            Console.WriteLine("Завдання: Знайти всі номерні знаки Рівненської області у форматі AA0000AO\n");

            // Заданий текст для аналізу
            string text = @"
                На парковці стояли автомобілі з номерами: 
                AB1234AO, KH5678BO, AI9999AO, ZZ0001AO, 
                BC1111AA, CD2222AO, EF3333KO, GH4444AO.
                Також були помічені номери: AB12AO (неправильний), 
                ABCD1234AO (неправильний), 12345AO (неправильний),
                AI0000AO, AA9876AO та XY5555AO.
                Деякі автомобілі мали іноземні номери: DE-AB-1234, 
                а деякі українські з інших областей: KI1234AA, LV5678BB.
            ";

            Console.WriteLine("Текст для аналізу:");
            Console.WriteLine(text);
            Console.WriteLine(new string('-', 60));

            // Виклик методу пошуку номерних знаків
            LicensePlateFinder finder = new LicensePlateFinder();
            finder.FindRivneLicensePlates(text);

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Клас для пошуку номерних знаків Рівненської області
    /// </summary>
    class LicensePlateFinder
    {
        private const string Pattern = @"\b[A-Z]{2}\d{4}AO\b";

        /// <summary>
        /// Знаходить всі номерні знаки Рівненської області у тексті
        /// </summary>
        /// <param name="text">Текст для пошуку</param>
        public void FindRivneLicensePlates(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("Текст порожній або null.");
                return;
            }

            Regex regex = new Regex(Pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(text);

            if (matches.Count > 0)
            {
                Console.WriteLine($"Знайдено номерних знаків Рівненської області: {matches.Count}\n");
                
                int counter = 1;
                foreach (Match match in matches)
                {
                    Console.WriteLine($"{counter}. {match.Value.ToUpper()}");
                    counter++;
                }
            }
            else
            {
                Console.WriteLine("Номерні знаки Рівненської області не знайдено.");
            }
        }
    }
}
