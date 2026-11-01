using System;

static class Rec
{
    public static int DigitSum(int n)
    {
        if (n == 0) return 0;

        return n % 10 + DigitSum(n / 10);
    }

    public static long Pow(int x, int n)
    {
        if (n == 0) return 1;

        return x * Pow(x, n - 1);
    }
}

class Program
{
    static void Main()
    {
        foreach (int n in new[] { 0, 7, 12345, 1000 })
            Console.WriteLine($"DigitSum({n}) = {Rec.DigitSum(n)}");

        Console.WriteLine($"Pow(2, 0) = {Rec.Pow(2, 0)}");
        Console.WriteLine($"Pow(2, 10) = {Rec.Pow(2, 10)}");
        Console.WriteLine($"Pow(5, 3) = {Rec.Pow(5, 3)}");
        Console.WriteLine($"Pow(7, 1) = {Rec.Pow(7, 1)}");
    }
}
