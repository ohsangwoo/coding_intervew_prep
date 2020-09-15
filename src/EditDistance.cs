using System;

public class EditDistance
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"{OneEditApart(args[0], args[1])}");
    }
    
       private static bool OneEditApart(string s1, string s2)
    {
        var lengthGap = s1.Length - s2.Length;
        
        if(lengthGap < -1 || lengthGap > 1)
            return false;
        
        if(lengthGap == 0)
        {
            var failCount = 0;
            for(var i = 1; i < s1.Length; i++)
            {
                if(s1[i] != s2[i])
                    failCount++;
            }
            
            return failCount <= 1;
        } 
        else if(lengthGap == 1)
        {
            return IsOneOff(s1, s2);
            
        } 
        else             
        {
            return IsOneOff(s2, s1);
        }            
    }
    
    private static bool IsOneOff (string s1, string s2)
    {
        // the length of s1 is always greater than the length of s2
        var failCount = 0;
        for(int i = 0; i < s1.Length; i++)
        {            
            if(s2.Length == i)
            {
                failCount++;
                continue;
            }
               
            if(s1[i] != s2[i-failCount])
            {
                failCount++;
            }
        }
        
         return failCount <= 1;
    }
}
