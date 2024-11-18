internal class Program
{
    public class MassItem
    {
        public int[] Data;
        public int[] Output;
    }

    public class MassData
    {
        private List<MassItem> massive;
        public MassData()
        {
            massive = new List<MassItem>(1000);
        }
        public void Add(MassItem item)
        {
            massive.Add(item);
            ThreadPool.QueueUserWorkItem(MethodForThread, item);
        }
        protected static void MethodForThread(object o)
        {
            MassItem item = (MassItem)o;
            List<int> F = new List<int>();
            Console.WriteLine("Поток {0}. Получен новый элемент [{1}]",
                Thread.CurrentThread.ManagedThreadId,
                string.Join(", ", item.Data));
            Console.WriteLine("Поток {0}. Поиск подмножеств в массиве [{1}]",
                    Thread.CurrentThread.ManagedThreadId,
                    string.Join(", ", item.Data));
            for (int i = 0; i < item.Data.Length; i++)
            {
                if (item.Data[i] % 3 == 0)
                {
                    F.Add(item.Data[i]);
                }
            }
            Thread.Sleep(100);
            item.Output = F.ToArray();
            if (item.Output.Length < 0) { Console.WriteLine("***0***"); }
            Console.WriteLine("Поток {0}. Вычисление завершено подмножества: [{1}] ",
                Thread.CurrentThread.ManagedThreadId,
                string.Join(", ",item.Output));
        }
    }
    static void Main(string[] args)
    {
        int MaxWorkThread;
        int MaxIOTread;
        ThreadPool.GetMaxThreads(out MaxWorkThread, out MaxIOTread);
        Console.WriteLine("Макс потоков {0}, Макс потоков ввода-вывода {1}", MaxWorkThread, MaxIOTread);
        MassData myData = new MassData();
        Random rnd = new Random();
        for (int i = 0; i < 100; i++)
        {
            int d = rnd.Next(5,20);
            int[] d1 = new int[d];
            for (int j = 0; j < d1.Length; j++)
            {
                d1[j] = rnd.Next(1,50);
            }
            myData.Add(new MassItem() { Data = d1 });
        }
        Console.ReadKey();
    }
}