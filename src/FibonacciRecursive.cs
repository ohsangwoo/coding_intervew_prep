using System;

public class FibonacciRecursive
{
    public static void Main(string[] args)
    {
        Console.WriteLine(GetFibonacci(int.Parse(args[0])));
    }

    private static int GetFibonacci(int n)
    {
        if(n == 1)
            return 0;
        
        if(n == 2)
            return 1;

        var result = GetFibonacci(n - 2) + GetFibonacci(n - 1);    
        return result;
    }

}
