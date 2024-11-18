internal class Program
{
    static void Main(string[] args)
    {
        const int colCount = 3, rowCount = 5;
        int[,] mass = new int[rowCount, colCount];
        Random rand = new Random();
        ParallelLoopResult res = Parallel.For(0, colCount, j =>
        {
            for (int i = 0; i < rowCount; i++)
            {
                mass[i, j] = rand.Next(20);
                Console.WriteLine("Матрица[{0}, {1}] = {2}\t Поток: {3}\t Задача: {4}",
                    i, j, mass[i, j],
                    Thread.CurrentThread.ManagedThreadId,
                    Task.CurrentId);
            }

        });
        Console.WriteLine("\nИнициализация завершена - {0}\n", res.IsCompleted);
        int sumMax = 0;
        int sum = 0;
        int idx = 0;
        res = Parallel.For(0, rowCount, j =>
        {
            for (int i = 0; i < colCount; i++)
            {
                sum += mass[j, i];
            }
            if (sum > sumMax)
            {
                sumMax = sum;
                idx = j;
            }
            Console.WriteLine("Сумма столбца {0} равна {1}", idx, sum);
            sum = 0;
        });
        Console.WriteLine("\nМаксимальная сумма столбца {0} равна {1}", idx, sumMax);
        Console.ReadKey();
    }
}