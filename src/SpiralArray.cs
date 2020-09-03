using System;

public class SpiralArray
{
    static void Main(string[] args)
    {
        if(args.Length < 1)
        {
            Console.WriteLine("Argument missing.");
            return;
        }

        if(!int.TryParse(args[0], out var n))
            return;
        
        var result = GetSprialArray(n);
        
        var paddingSize = string.Format("{0}", result.Length).Length;
        
        for(var i = 0; i < n ; i++)
        {
            for(var j = 0; j < n ; j++)
            {
                Console.Write($"{result[i, j].ToString().PadRight(paddingSize)} " );
            }
            Console.WriteLine();
        }
    }
    static int[,] GetSprialArray(int n)
    {
        var matrix = new int[n,n];
        
        var row = 0;
        var column = 0;
        var direction = 0;
        
        for(var i = 1; i <= n*n ; i++)
        {
            matrix[row, column] = i;
            
            if(!CanMoveNext(matrix, row, column, n, direction))
            {
                direction = (direction+1) % 4;
            }
            
            MoveNext(ref row, ref column, direction);            
        }
           
        return matrix;
        
    }
    
    static void MoveNext(ref int row, ref int column, int direction)   
    {
        
        switch (direction){
                case 0: 
                    column++;
                    break;
                case 1:
                    row++;
                    break;
                case 2: 
                    column--;
                    break;
                case 3:
                    row--;
                    break;
            }
    }
    
    static bool CanMoveNext(int[,] matrix, int x, int y, int n, int direction)
    {
        MoveNext(ref x,ref y, direction);
            
        return x >= 0 && y >= 0 && x < n && y < n && matrix[x, y] == 0;
    }
    
}
