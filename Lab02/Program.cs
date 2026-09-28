using System;

class Program
{
    static void Task1(int[] a)
    {
        if (a.Length == 0)
        {
            Console.WriteLine("Результат не визначений.");
            return;
        }

        int sum = 0;
        int min = a[0];
        int max = a[0];
        int minIndex = 0;
        int maxIndex = 0;
        int zeroCount = 0;

        for (int i = 0; i < a.Length; i++)
        {
            sum += a[i];

            if (a[i] < min)
            {
                min = a[i];
                minIndex = i;
            }

            if (a[i] > max)
            {
                max = a[i];
                maxIndex = i;
            }

            if (a[i] == 0)
                zeroCount++;
        }

        double average = (double)sum / a.Length;

        Console.WriteLine("Завдання 1:");
        Console.WriteLine("Сума: " + sum);
        Console.WriteLine("Середнє: " + average);
        Console.WriteLine("Мінімум: " + min + ", індекс: " + minIndex);
        Console.WriteLine("Максимум: " + max + ", індекс: " + maxIndex);
        Console.WriteLine("Кількість нулів: " + zeroCount);
    }

    static int[] Task2(int[] a)
    {
        int count = 0;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] < 1)
                count++;
        }

        int[] result = new int[count];
        int j = 0;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] < 1)
            {
                result[j] = a[i];
                j++;
            }
        }

        return result;
    }

    static void Task3(int[] a)
    {
        if (a.Length == 0)
        {
            Console.WriteLine("Результат не визначений.");
            return;
        }

        int currentValue = a[0];
        int currentLength = 1;
        int currentStart = 0;

        int bestValue = a[0];
        int bestLength = 1;
        int bestStart = 0;

        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] == currentValue)
            {
                currentLength++;
            }
            else
            {
                if (currentLength > bestLength)
                {
                    bestValue = currentValue;
                    bestLength = currentLength;
                    bestStart = currentStart;
                }

                currentValue = a[i];
                currentLength = 1;
                currentStart = i;
            }
        }

        if (currentLength > bestLength)
        {
            bestValue = currentValue;
            bestLength = currentLength;
            bestStart = currentStart;
        }

        Console.WriteLine("Завдання 3:");
        Console.WriteLine("Значення: " + bestValue);
        Console.WriteLine("Довжина: " + bestLength);
        Console.WriteLine("Індекс початку: " + bestStart);
    }

    static void Task4(int[] a)
    {
        if (a.Length == 0)
        {
            Console.WriteLine("Масив порожній.");
            return;
        }

        int half = a.Length / 2;

        for (int i = 0; i < half; i++)
        {
            int temp = a[i];
            a[i] = a[i + half];
            a[i + half] = temp;
        }
    }

    static int[,] Task5(
        out int[] rowSums,
        out int[] columnMax,
        out int maxSumRow)
    {
        int[,] matrix = new int[3, 6];
        Random random = new Random(14);

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                matrix[i, j] = random.Next(1, 5);
        }

        rowSums = new int[matrix.GetLength(0)];
        columnMax = new int[matrix.GetLength(1)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                rowSums[i] += matrix[i, j];
        }

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            columnMax[j] = matrix[0, j];

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] > columnMax[j])
                    columnMax[j] = matrix[i, j];
            }
        }

        maxSumRow = 0;

        for (int i = 1; i < rowSums.Length; i++)
        {
            if (rowSums[i] > rowSums[maxSumRow])
                maxSumRow = i;
        }

        return matrix;
    }

    static void PrintArray(int[] a)
    {
        Console.Write("[ ");

        for (int i = 0; i < a.Length; i++)
        {
            Console.Write(a[i]);

            if (i < a.Length - 1)
                Console.Write(", ");
        }

        Console.WriteLine(" ]");
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        const int N = 14;

        int[] a = new int[24];
        Random random = new Random(N);

        for (int i = 0; i < a.Length; i++)
            a[i] = random.Next(1, 5);

        Console.WriteLine("N = 14, K = 1, a = 2, b = 2, c = 4");
        PrintArray(a);

        Task1(a);

        int[] filtered = Task2(a);
        Console.WriteLine("Завдання 2:");
        PrintArray(filtered);

        Task3(a);

        Console.WriteLine("Завдання 4:");
        PrintArray(a);
        Task4(a);
        PrintArray(a);

        int[] rowSums;
        int[] columnMax;
        int maxSumRow;

        int[,] matrix = Task5(
            out rowSums,
            out columnMax,
            out maxSumRow
        );

        Console.WriteLine("Завдання 5:");
        PrintMatrix(matrix);

        Console.WriteLine("Суми рядків:");

        for (int i = 0; i < rowSums.Length; i++)
            Console.WriteLine(rowSums[i]);

        Console.WriteLine("Максимуми стовпців:");

        for (int i = 0; i < columnMax.Length; i++)
            Console.WriteLine(columnMax[i]);

        Console.WriteLine("Рядок з найбільшою сумою: " + maxSumRow);
    }
}

