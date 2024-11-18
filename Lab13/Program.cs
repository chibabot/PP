internal class Program
{
    public class TaskResult
    {
        public int[] Data;
        public int[] Output;
    }

    public static TaskResult MethodForTask(object o)
    {
        TaskResult item = new TaskResult();
        item.Data = (int[])o;
        List<int> F = new List<int>();
        Console.WriteLine("Задача. Поиск подмножеств в массиве делящихся на 3 [{0}]",
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
        Console.WriteLine("Задача. Вычисление завершено.");
        return item;
    }
    static void Main(string[] args)
    {
        int[] mass = new int[20];
        Random rand= new Random();
        for (int i = 0; i < mass.Length; i++)
        {
            mass[i] = rand.Next(1,20);
        }
        var TaskWithResult = new Task<TaskResult>(MethodForTask, mass);
        TaskWithResult.Start();
        Console.WriteLine("Подмножество: [{0}]", string.Join(", ",TaskWithResult.Result.Output));
        Console.ReadKey();
    }
}