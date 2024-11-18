class Program
{
    public static void Main(string[] args)
    {
        Func<Action<bool>, float, float> lambda = Function;
        Action<bool> action = Method;

        Console.WriteLine(lambda(action, 4.0f)); // True
        Console.ReadLine();
        Console.WriteLine(lambda(action, 4.5f)); // False
        Console.ReadLine();
        Console.WriteLine(lambda(action, 3.0f)); // False
        Console.ReadLine();
        Console.WriteLine(lambda(action, 3.5f)); // False
        Console.ReadLine();
    }
    static void Method(bool s)
    {
        Console.WriteLine(s); // Вывод логического выражения
    }

    static float Function(Action<bool> action, float num)
    {
        //Проверка на четность числа с плавающей точкой
        float res = num % 2;
        action(res==0); // Проверка на четность
        return res; // Вывод остатка от деления на 2
    }
}