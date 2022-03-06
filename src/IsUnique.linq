<Query Kind="Program" />

// CCI 1.1 Is Unique
void Main()
{
	//Test Cases
	Console.WriteLine(IsUnique("batman"));
	Console.WriteLine(IsUnique("riddler"));
	Console.WriteLine(IsUnique("joker"));
	Console.WriteLine(IsUnique("abc  def"));
}

// Runtime Complexity: S = the size of string O(S + 1) => O(S)
// Space Complexity: S = the size of string O(S)
public bool IsUnique(string input)
{
	var hash = new HashSet<char>();

	for(int i = 0; i < input.Length; i++)
	{
		if(!hash.Contains(input[i]))
		{
			hash.Add(input[i]);
			continue;
		}	
		
		return false;
	}
	
	return true;
}
	