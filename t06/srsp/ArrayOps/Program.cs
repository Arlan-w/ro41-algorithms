using System;

static class ArrayOps
{
    public static int Sum(int[] a)
    {
        int sum = 0;
        for (int i = 0; i < a.Length; i++)
            sum += a[i];
        return sum;
    }

    public static int IndexOfMin(int[] a)
    {
        int minIndex = 0;
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] < a[minIndex])
                minIndex = i;
        }
        return minIndex;
    }

    public static int CountGreater(int[] a, int x)
    {
        int count = 0;
        for (int i = 0; i < a.Length; i++)
            if (a[i] > x) count++;
        return count;
    }

    public static void Reverse(int[] a)
    {
        // идём только до середины, меняем a[i] и a[n-1-i]
        for (int i = 0; i < a.Length / 2; i++)
        {
            int tmp = a[i];
            a[i] = a[a.Length - 1 - i];
            a[a.Length - 1 - i] = tmp;
        }
    }
}

class Program
{
    static string Show(int[] a) => "{" + string.Join(", ", a) + "}";

    static void Main()
    {
        int[][] tests =
        {
            new[] { 4, 1, 7, 3, 9 },
            new[] { 5 },
            new[] { -2, -7, -4 },
            new[] { 2, 2, 2 }
        };

        foreach (int[] a in tests)
        {
            Console.WriteLine("Массив: " + Show(a));
            Console.WriteLine("Sum = " + ArrayOps.Sum(a));
            Console.WriteLine("IndexOfMin = " + ArrayOps.IndexOfMin(a));
            Console.WriteLine("CountGreater(x = 2) = " + ArrayOps.CountGreater(a, 2));
            ArrayOps.Reverse(a);
            Console.WriteLine("После Reverse: " + Show(a));
            Console.WriteLine();
        }
    }
}
