internal class Program
{
    public delegate int TakesAWhileDelegate(int data, int ms);
    static int TakesAWhile(int data, int ms)
    {
        Console.WriteLine("TakesAWhile запущен");
        Thread.Sleep(ms);
        Console.WriteLine("TakesAWhile завершен");
        return ++data;
    }
    static void Main(string[] args)
    {
        TakesAWhileDelegate dl = TakesAWhile;
        IAsyncResult ar = dl.BeginInvoke(1, 3000, null, null);
        while (true)
        {
            Console.Write(" . ");
            if (ar.AsyncWaitHandle.WaitOne(50, false))
            {
                Console.WriteLine("Можно извлечь результат сейчас");
                break;
            }
        }
        int result = dl.EndInvoke(ar);
        Console.WriteLine("result: (0}", result);
    }
}