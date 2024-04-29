using System;

class Program
{
    static void Main(string[] args)
    {
        
    Random randomGenerator = new Random();
    int number = randomGenerator.Next(1, 101);

        int guessNumber;
        string HigherLower = "";

        while (true)
        {
            Console.Write("What is your guess? ");
            string guess = Console.ReadLine();
            guessNumber = int.Parse(guess);

            if (guessNumber == number)
            {
                Console.WriteLine("You guessed it!");
                break; 
            }
            else if (guessNumber < number)
            {
                HigherLower = "Higher";
            }
            else if (guessNumber > number)
            {
                HigherLower = "Lower";
            }

            Console.WriteLine(HigherLower);
        }
    }
}
