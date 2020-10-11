using System;
using System.Collections.Generic;

// Letter Combinations of a Phone Number
// https://leetcode.com/problems/letter-combinations-of-a-phone-number/

public class LetterCombinationOfPhoneNumber {
    private static Dictionary<char, string> _mapping = new Dictionary<char, string>()
    {
        { '2', "abc "},
        { '3', "def "},
        { '4', "ghi "},
        { '5', "jkl "},
        { '6', "mno "},
        { '7', "pqrs"},
        { '8', "tuv "},
        { '9', "wxyz"}
    };
    
    public static void Main(string[] args)
    {
        var combinations = LetterCombinations(args[0]);
        foreach(var combination in combinations)
        {
            Console.WriteLine(combination);
        }
    }

    public static IList<string> LetterCombinations(string digits) {
        var output = new List<string>();
        
        // n = 4
        // 3 4 8 9
        // 0 -> 4^n 

        // 0 => 0 0 0 0 => d g t w
        // 1 => 0 0 0 1 => d g t y
        // 9 => 0 0 2 1 => d g u y

        for(int i = 0; i < Math.Pow(4, digits.Length); i++)
        {
            var keys = GetBase4Number(i, digits.Length);

            var combination = GetCombination(digits, keys);
            if( !string.IsNullOrEmpty(combination))
            {
                output.Add(combination);
            }
        }

        return output;
    }

    private static string GetBase4Number(int number, int length)
    {
        var base4Number = string.Empty;

        for(int i = length- 1; i > 0; i--)
        {
            var baseNumber = (int) Math.Pow(4, i);
            base4Number = $"{base4Number}{number/baseNumber}";
            number = number % baseNumber;
        }

        return $"{base4Number}{number}";
    }

    private static string GetCombination(string digits, string keys)
    {
        var combination = string.Empty;

        for(var i = 0; i < digits.Length; i++)
        {
            var keyIndex = keys[i] - (char)'0';
            var character = _mapping[digits[i]][keyIndex];
            if(character != ' ')
            {
                combination = string.Concat(combination, character);
            }

            if(character == ' ' && keyIndex > 0)
            {
                return string.Empty;
            }
        }

        return combination;
    }
}