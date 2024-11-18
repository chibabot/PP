internal class Program
{
    static void Main(string[] args)
    {
        Task t1 = new Task(ParallelTask);
        t1.Start();
        TaskFactory tf = new TaskFactory();
        Task t2 = tf.StartNew(ParallelTask);
        Task t3 = Task.Factory.StartNew(ParallelTask);
        Console.ReadKey();
    }
    public static void ParallelTask()
    {
        Console.WriteLine("Выполнение задачи {0}. Выполнение алгоритма.", 
            Task.CurrentId);
        Random random = new Random();
        int[] mass = new int[10];
        for (int i = 0; i < 10; i++)
        {
            mass[i] = random.Next(1,20);
        }
        Console.WriteLine("Выполнение задачи {0}. Инициализация массива: [{1}]",
            Task.CurrentId,
            string.Join(", ",mass));
        int max=0;
        for (int i = 0; i < mass.Length; i++)
        {
            if (max < mass[i]) {max = mass[i];}
        }
        Console.WriteLine("Выполнение задачи  {0}. Максимальное число в массиве = {1}",
            Task.CurrentId,
            max);
    }
}