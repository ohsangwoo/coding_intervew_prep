using System;

// Facebook Sample Interview questions - Question 2: Look and Say
// Reference: https://www.facebook.com/careers/life/sample_interview_questions

class LookAndSay
{
    static void Main(string[] args)
    {
        var startNumber = args[0];
        var n = int.Parse(args[1]);
        
        for (var i = 0; i < n; i++)
        {
            Console.WriteLine(startNumber);
            startNumber = GetLookAndSayArray(startNumber);
        }
        
    }  
    
    private static string GetLookAndSayArray(string numberToSay)   
    {
        var number = string.Empty;
        var count = 0;
        var currentNumber = numberToSay[0];
        
        for(var n = 0; n < numberToSay.Length; n++)
        {
            if(currentNumber == numberToSay[n])
            {
                count++;
            }
            else    
            {
                number = $"{number}{count}{currentNumber}";
                currentNumber = numberToSay[n];
                count = 1;
            }
        }
        
        number = $"{number}{count}{currentNumber}";
        return number;
        
    }
}
