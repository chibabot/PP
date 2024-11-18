internal class Program
{
    static void Main(string[] args)
    {
        Task<int[]> tBase = new Task<int[]>(() =>
        {
            Random rand = new Random();
            int randomLength = rand.Next(5, 10);
            Console.WriteLine("Основная задача. Инициализация массива размером {0}.", randomLength);
            int[] mass = new int[randomLength];
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = rand.Next(5, 20);
            }
            Console.WriteLine("Основная задача. Массив: [{0}]", string.Join(", ", mass));
            return mass;
        });
        Task t1 = tBase.ContinueWith(tbase =>
        {
            int[] mass = tbase.Result;
            Console.WriteLine("Задача {0}. Поиск минимального значения среди нечетных", tbase.Id);
            int min = 1000;
            for (int i = 0; i < mass.Length; i++)
            {
                if (min > mass[i] && mass[i] % 2 == 1) { min = mass[i]; }
            }
            Console.WriteLine("Задача {0}. Минимальное значение среди нечетных равно {1}", tbase.Id, min);
        });
        Task t2 = tBase.ContinueWith(tbase =>
        {
            Console.WriteLine("Задача {0}. Поиск количества элементов делящихся на 7.", tbase.Id);
            int[] mass = tbase.Result;
            int count = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] % 7 == 0) { count++; }
            }
            Console.WriteLine("Задача {0}. Количество элементов делящихся на 7 равно {1}", tbase.Id, count);
        });
        tBase.Start();
        Console.ReadKey();
    }
}