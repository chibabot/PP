internal class Program
{
    public struct Data
    {
        public int X;
        public int Y;
    }
    static void ThreadMainWithParameters(object o)
    {
        Data d = (Data)o;
        Console.WriteLine("Выполняется в потоке, получено {0},{1}", d.X,d.Y);
        SumArray(d.X,d.Y);
    }
    static void SumArray(int X, int Y)
    {
        int threadID = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine("Поток {0}. Создание массива...", threadID);
        int M = X;
        int N = Y;

        int[,] mas = new int[M, N];
        Console.WriteLine("Поток {0}. Инициализация элементов массива...", threadID);
        Random rnd = new Random();
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                mas[i, j] = rnd.Next(50);
            }
        }
        Console.WriteLine("Поток {0}. Вычисление суммы элементов матрицы...", threadID);
        int sum = 0;
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                sum += mas[i, j];
            }
            Console.WriteLine("Поток {0}. Сумма элементов матрицы = {1}.", threadID, sum);
        }
    }
    static void Main(string[] args)
    {
        Thread[] tmas = new Thread[20];
        Random rand = new Random();
        for (int i = 0; i < 20; i++)
        {
            var d = new Data { X = rand.Next(1, 10), Y = rand.Next(1, 10) };
            tmas[i] = new Thread(ThreadMainWithParameters);
            tmas[i].Start(d);
        }
        Console.ReadKey();

    }
}