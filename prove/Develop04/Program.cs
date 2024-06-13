using System;
using System.Diagnostics;
class Program
{
    static void Main(string[] args)
    {
        int user_input = 0;
        int seconds = 0;
        ActivityInfomation a1 = new ActivityInfomation(seconds);
        Breathing b1 = new Breathing(seconds);
        Reflecting r1 = new Reflecting(seconds);
        Listing l1 = new Listing(seconds);
        while (user_input != 4)
        {
            Console.WriteLine("Menu Options:\n   1. Start breathing activity" +
            "\n   2. Start reflecting activity\n   3. Start listing activity" +
            "\n   4. Quit");
            Console.Write("Select a choice from the menu: ");
            user_input = int.Parse(Console.ReadLine());
            Console.Clear();
            if (user_input > 0 && user_input < 4)
            {
                string activity = a1.GetActivityName(user_input);
                Console.WriteLine($"Welcome to the " +
                $"{activity}\n\n{a1.GetActivity(user_input)}");
                Console.Write("\nHow long, in seconds, would you like for your session? ");     //Could potentially put this whole section into a class if I wanted to
                seconds = int.Parse(Console.ReadLine());
                TimedItems t1 = new TimedItems(seconds);
                Console.Clear();
                Console.WriteLine("Get ready...");
                Console.WriteLine(t1.LoadingAnimation(5));
                if (user_input == 1)   // Breathing Activity
                {
                    Console.WriteLine(b1.GetBreathingActivity(seconds));
                }
                else if (user_input == 2)   // Reflecting Activity
                {
                    Console.WriteLine(r1.GetReflectionActivity(seconds));
                }
                else if (user_input == 3)   //Listing Activity
                {
                    Console.WriteLine(l1.GetListingActivity(seconds));
                }
                Console.WriteLine(a1.GetActivityStats(activity, seconds));
                Console.Clear();
            }
            else if (user_input == 4)
            {
                Console.WriteLine("Hope this helped you!\n");
            }
            else
            {
                Console.WriteLine("That wasn't an option.\n");
            }
        }
    }
}