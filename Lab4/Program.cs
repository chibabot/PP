using System.Diagnostics;
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
        dl.BeginInvoke(1, 3000, TakesAWhileCompleted, dl);
        for (int i = 0; i <100; i++)
        {
            Console.WriteLine(".");
            Thread.Sleep(50);
        }
    }
    static void TakesAWhileCompleted(IAsyncResult ar)
    {
        if (ar == null) throw new ArgumentNullException("ar");
        TakesAWhileDelegate? dl = ar.AsyncState as TakesAWhileDelegate;
        Trace.Assert(dl != null, "Invalid object type");
        int result = dl.EndInvoke(ar);
        Console.WriteLine("result {0}", result);
    }
}