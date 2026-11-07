using System;

static class ArrayAlgos
{
    // Проверка сортировки массива
    public static bool IsSorted(int[] a)
    {
        if (a == null)
            return false;

        for (int i = 0; i < a.Length - 1; i++)
        {
            if (a[i] > a[i + 1])
                return false;
        }

        return true;
    }

    // Сортировка пузырьком
    public static int BubbleSort(int[] a)
    {
        if (a == null)
            return 0;

        int comparisons = 0;

        for (int i = 0; i < a.Length - 1; i++)
        {
            bool swapped = false;

            for (int j = 0; j < a.Length - 1 - i; j++)
            {
                comparisons++;

                if (a[j] > a[j + 1])
                {
                    int temp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = temp;

                    swapped = true;
                }
            }

            if (!swapped)
                break;
        }

        return comparisons;
    }

    // Подсчёт количества вхождений через бинарный поиск
    public static int CountOccurrences(int[] sortedA, int x)
    {
        if (sortedA == null)
            return 0;

        int left = 0;
        int right = sortedA.Length;

        // Первый индекс элемента >= x
        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (sortedA[mid] < x)
                left = mid + 1;
            else
                right = mid;
        }

        int first = left;

        left = 0;
        right = sortedA.Length;

        // Первый индекс элемента > x
        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (sortedA[mid] <= x)
                left = mid + 1;
            else
                right = mid;
        }

        int last = left;

        return last - first;
    }
}

class Program
{
    static void Main()
    {
        int[][] tests =
        {
            new int[] { },
            new int[] { 5 },
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 5, 4, 3, 2, 1 },
            new int[] { 3, 1, 3, 2, 3 }
        };

        Console.WriteLine("=== BUBBLE SORT ===");

        foreach (int[] a in tests)
        {
            int[] original = (int[])a.Clone();

            int comparisons = ArrayAlgos.BubbleSort(a);

            Console.WriteLine("Массив до: " +
                string.Join(", ", original));

            Console.WriteLine("Массив после: " +
                string.Join(", ", a));

            Console.WriteLine("IsSorted: " +
                ArrayAlgos.IsSorted(a));

            Console.WriteLine("Сравнений: " + comparisons);
            Console.WriteLine("------------------------");
        }

        // Проверка массива из 1000 элементов
        int[] largeArray = new int[1000];

        for (int i = 0; i < 1000; i++)
            largeArray[i] = i + 1;

        int count = ArrayAlgos.BubbleSort(largeArray);

        Console.WriteLine("1000 элементов: " + count);
        Console.WriteLine("Ожидается: 999");

        // Проверка CountOccurrences
        int[] sortedA = { 1, 2, 2, 2, 5, 7 };

        int[] numbers = { 2, 1, 7, 3, 9 };
        int[] expected = { 3, 1, 1, 0, 0 };

        Console.WriteLine("\n=== COUNT OCCURRENCES ===");

        for (int i = 0; i < numbers.Length; i++)
        {
            int result = ArrayAlgos.CountOccurrences(
                sortedA, numbers[i]);

            Console.WriteLine(
                "Число: " + numbers[i] +
                " | Ожидалось: " + expected[i] +
                " | Получено: " + result +
                " | " + (result == expected[i] ? "OK" : "FAIL")
            );
        }
    }
}
