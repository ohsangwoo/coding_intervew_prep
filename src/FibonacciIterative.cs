using System;

public class FibonacciIterative
{
    public static void Main(string[] args)
    {
        Console.WriteLine(GetFibonacci(int.Parse(args[0])));
    }

    private static int GetFibonacci(int n)
    {
        var previousNumbers = new int[2] {0, 1};

        if(n == 1)
            return previousNumbers[0];
        
        if(n == 2)
            return previousNumbers[1];


        for(var i = 2; i < n; i++ )
        {
            var sum = previousNumbers[0] + previousNumbers[1];
            previousNumbers[0] = previousNumbers[1];
            previousNumbers[1] = sum;
        }

        return previousNumbers[1];
    }

}
