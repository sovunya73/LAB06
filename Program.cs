using System;
using System.Text;

namespace LAB06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("1. Конструкторы и ToString()");
            CustomTime t1 = new CustomTime(14, 35, 20);
            CustomTime t2 = new CustomTime(9);
            CustomTime t3 = new CustomTime(23, 50, 7);
            Console.WriteLine($"t1 = {t1}");
            Console.WriteLine($"t2 = {t2}");
            Console.WriteLine($"t3 = {t3}");

            Console.WriteLine("2. Свойства");
            CustomTime t4 = new CustomTime(0);
            t4.Hour = 9;
            t4.Minute = 5;
            t4.Second = 7;
            Console.WriteLine($"t4 = {t4}");
            Console.WriteLine($"Часы: {t4.Hour}, минуты: {t4.Minute}, секунды: {t4.Second}");

            Console.WriteLine("3. Проверка некорректных значений");
            try
            {
                t4.Hour = 24;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            try
            {
                t4.Minute = 60;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            try
            {
                CustomTime wrong = new CustomTime(10, 10, -12);
                Console.WriteLine(wrong);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine($"t4 не изменился: {t4}");

            Console.WriteLine("4. Оператор + (добавление минут)");
            Console.WriteLine($"{t1} + 30 = {t1 + 30}");
            Console.WriteLine($"{t3} + 20 = {t3 + 20}");     
            Console.WriteLine($"{t2} + 1500 = {t2 + 1500}"); 

            Console.WriteLine("5. Оператор - (вычитание минут)");
            Console.WriteLine($"{t1} - 40 = {t1 - 40}");
            CustomTime early = new CustomTime(0, 10, 0);
            Console.WriteLine($"{early} - 30 = {early - 30}"); 
            Console.WriteLine($"{t2} - 3000 = {t2 - 3000}");   

            Console.WriteLine("6. Разность двух времён");
            Console.WriteLine($"{t1} - {t2} = {t1 - t2} мин.");
            Console.WriteLine($"{t2} - {t1} = {t2 - t1} мин.");

        }
    }
}
