using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите целое число n (n >= 0): ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int n) || n < 0)
        {
            Console.WriteLine("Ошибка: введите целое число не меньше 0.");
            return;
        }

        int temp = n;
        int sum = 0;
        int count = 0;

        while (temp > 0)
        {
            int digit = temp % 10;
            sum += digit;
            count++;
            temp /= 10;
        }

        if (count == 0)
        {
            count = 1;
        }

        Console.WriteLine($"Количество цифр: {count}");
        Console.WriteLine($"Сумма цифр: {sum}");
    }
}