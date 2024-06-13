public class Listing : TimedItems
{
    private List<string> _lQuestions;
 
    public Listing(int seconds) : base (seconds)
    {
        _lQuestions = ["Who are people you appreciate?","What are personal strengths of yours?",
        "Who are people that you have helped this week?","Who are some of your personal heros?",
        "When have you felt the Holy Ghost this month?"];
    }
    public string GetListingQuestion()
    {
        int number = _lQuestions.Count();
        Random rand = new Random();
        int r1 = rand.Next(number);
        string question = _lQuestions[r1];
        _lQuestions.RemoveAt(r1);
        return question;
    }
    public string GetListingActivity(int seconds)
    {
        string listing_question = GetListingQuestion();
        List<string> listing = [listing_question];
        Console.WriteLine($"List as many responses you can to the following prompt:\n\n --- " +
        $"{listing_question} ---");
        Console.Write(CountdownAnimation());
        Console.WriteLine("");
        DateTime endtime = TimeLimit(seconds);
        while (DateTime.Now < endtime)
        {
            Console.Write(">");
            string entry = Console.ReadLine();
            listing.Add(entry);
        }
        using (StreamWriter outputfile = new StreamWriter("Listing.txt"))
        {
            outputfile.WriteLine("Listing Activity Infomation:");
            foreach (var array in listing)
            {
                outputfile.WriteLine(array);
            }
        }
        return "";
    }
}