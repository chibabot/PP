internal class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        Func<int[], int, int> lambda = countSubsets;
        var arr = new int[15];
        for (int i = 0; i < arr.Length; i++)
            arr[i] = rand.Next(0, 15);
        int n = arr.Length;
        var str = string.Join(" ", arr);
        Console.WriteLine(str);
        Console.WriteLine("Number of subsets = " + countSubsets(arr, n));
    }
    static int countSubsets(int[] arr, int n)
    {
        HashSet<int> us = new HashSet<int>();
        int even_count = 0;
        for (int i = 0; i < n; i++)
            if (arr[i] % 2 == 0)
                us.Add(arr[i]);
        even_count = us.Count;
        return (int)(Math.Pow(2, even_count) - 1);
    }
}