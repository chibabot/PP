internal class Program
{
    static void AvgArray()
    {
        int threadID = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine("Поток {0}. Создание массива...", threadID);
        int N = 10;
        int[] mas= new int[N];
        Console.WriteLine("Поток {0}. Инициализация элементов массива...", threadID);
        Random rnd = new Random();
        for (int i=0; i<N; i++)
        {
            mas[i] = rnd.Next(1000);
        }
        Console.WriteLine("Поток {0}. Массив: [{1}]", threadID, string.Join(", ",mas));
        Console.WriteLine("Поток {0}. Вычисление среднего арифметического матрицы...", threadID);
        int sum = 0;
        for (int i = 0; i < mas.Length; i++)
            sum += mas[i];
        float result = sum / mas.Length;
        Console.WriteLine("Поток {0}. Среднего арифметического матрицы = {1}.", threadID,result);
    }
    static void Main(string[] args)
    {
        Action method = AvgArray;
        Thread[] tmas = new Thread[20];
        for (int i = 0;i<20;i++)
        {
            tmas[i] = new Thread(AvgArray);
            tmas[i].Start();
        }
        Console.ReadKey();
    }
}