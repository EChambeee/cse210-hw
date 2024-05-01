using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int numList = -1;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (numList != 0)
        {
            Console.Write("Enter number: ");
            string userResponse = Console.ReadLine();
            numList = int.Parse(userResponse);

            if (numList != 0)
            {
                numbers.Add(numList);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        
        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}