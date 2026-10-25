using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество секунд: ");
        string input = Console.ReadLine() ?? "";

        if (!int.TryParse(input, out int n) || n < 0)
        {
            Console.WriteLine("Ошибка: введите целое неотрицательное число.");
            return;
        }

        int hours = n / 3600;
        int minutes = (n % 3600) / 60;
        int seconds = n % 60;

        Console.WriteLine($"Часы: {hours}");
        Console.WriteLine($"Минуты: {minutes}");
        Console.WriteLine($"Секунды: {seconds}");
    }
}