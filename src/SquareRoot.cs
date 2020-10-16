using System;

public class SquareRoot{
    public static void Main(string[] args)
    {
        var solution = new Solution();
        Console.WriteLine(solution.sqrt(int.Parse(args[0])));
    }
}
class Solution {
    public int sqrt(int A) {
        if ( A == 0 )
            return 0;
        
        var answer = 0;
        var skipCount = 1;

        while(skipCount > 0)
        {
            Console.WriteLine($"answer:{answer} skipCount:{skipCount} a*a: {answer*answer}");
            if(answer * answer == A)
                return answer;

            if(answer*answer < 0 || answer * answer > A)
            {
                skipCount = skipCount / 2;
                answer = answer - skipCount;
            } else
            {
                skipCount = skipCount * 2;
                answer = answer + skipCount;
            }
        }

        if(answer * answer < 0 || answer * answer > A)              
            return answer - 1;

        return answer;
    }
}
