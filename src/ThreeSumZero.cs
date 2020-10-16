using System;
using System.Collections.Generic;
using System.Linq;

public class ThreeSumZero
{
    public static void Main(string[] args)
    {
        var input = args.Select(t => int.Parse(t)).ToList();
        
        var solution = new Solution();

        var output = solution.threeSum(input);

        foreach(var element in output)
        {
            Console.Write($"[{element[0]}, {element[1]}, {element[2]}] ");
            Console.WriteLine();
        }
    }
}
public class Solution {
    public List<List<int>> threeSum(List<int> A) {
        var result = new List<List<int>>();
        
        var n = A.Count;
        var sortedArray = A.OrderBy(a => a).ToList();
        
         foreach(var a in sortedArray)
         {
             Console.Write($"{a} ");
        }

        var borderLine = findBorderLineIndex(sortedArray);
     //   Console.WriteLine($"Border:{borderLine}");
        if(borderLine == 0)
        {
            return result;
        }
        
        // 1 from left 2 from right
        for(int i = borderLine; i < n-1; i++)
        {
            for(int j = i + 1; j < n; j++)
            {
                var index = sortedArray.IndexOf( (sortedArray[i] + sortedArray[j]) * -1 );
                //Console.WriteLine($"{i}:{j} - {index}");
                if(index >= 0 && index <= borderLine )
                {

                    addUniqueTriplet(result, new List<int> { sortedArray[index], sortedArray[i], sortedArray[j]});
                    // var triplet = new List<int> { sortedArray[index], sortedArray[i], sortedArray[j] };
                    
                    // if(!result.Contains(triplet))
                    // {
                    //     result.Add(triplet);
                    // }
                }
            }
        }
        
        // 2 from left 1 from right
        for(int i = 0; i <= borderLine; i++)
        {
            for(int j = i + 1 ; j <= borderLine+1; j++)
            {
                var index = sortedArray.IndexOf( (sortedArray[i] + sortedArray[j]) * -1 );
                if(index > borderLine )
                {
                     addUniqueTriplet(result,  new List<int> { sortedArray[i], sortedArray[j], sortedArray[index] });
                    // var triplet = ;
                    // if(!result.Contains(triplet))
                    // {
                    //     result.Add(triplet);
                    // }
                }
            }
        }
        
        return result;
        
    }
    
    private void addUniqueTriplet(List<List<int>> list, List<int> triplet)
    {
        foreach(var item in list)
        {
            if(item[0] == triplet[0] && item[1] == triplet[1] && item[2] == triplet[2])
            {
                return;
            }
        }

        list.Add(triplet);

    }
    private int findBorderLineIndex(List<int> sortedArray)
    {
        for(int i = 0; i < sortedArray.Count; i++)
        {
            if(sortedArray[i] > 0)
                return i;
        }
        
        return 0;
    }
}
