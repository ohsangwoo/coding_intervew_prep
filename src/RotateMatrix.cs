using System;

public class RotateMatrix
{
    static void Main(string[] args)
    {
        var n = int.Parse(args[0]);
        var matrix = GetSqureMatrix(n);

        PrintMatrix(matrix, n);

        var rotated = Rotate(matrix, 0);
        PrintMatrix(rotated, n);

    }

    private static int[,] GetSqureMatrix(int n)
    {
        var matrix = new int[n, n];
        for (int i = 0; i < n * n; i++)
        {
            matrix[i / n, i % n] = i + 1;
        }

        return matrix;
    }

    private static int[,] Rotate(int[,] matrix, int startIndex)
    {
        var endIndex = (int)Math.Sqrt(matrix.Length) - 1 - startIndex;
        if (startIndex >= endIndex)
        {
            return matrix;
        }

        for (int i = 0; i < endIndex - startIndex; i++)
        {
            var temp = matrix[startIndex, startIndex + i];
            matrix[startIndex, startIndex + i] = matrix[endIndex - i, startIndex];
            matrix[endIndex - i, startIndex] = matrix[endIndex, endIndex - i];
            matrix[endIndex, endIndex - i] = matrix[startIndex + i, endIndex];
            matrix[startIndex + i, endIndex] = temp;
        }

        return Rotate(matrix, startIndex + 1);
    }


    private static void PrintMatrix(int[,] matrix, int n)
    {
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("======================");
    }

}
