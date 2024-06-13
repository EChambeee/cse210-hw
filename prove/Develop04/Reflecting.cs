public class Reflecting : TimedItems
{
    private List<string> _rQuestions;
    private List<string> _reflections;
 
    public Reflecting(int seconds) : base (seconds)
    {
        _rQuestions = ["stood up for someone else.","did something really difficult.",
        "helped someone in need.","did something truly selfless."];
 
        _reflections = ["Why was this experience meaningful to you?",
        "Have you ever done anything like this before?","How did you get started?",
        "How did you feel when it was complete?","What is your favorite thing about this experience?",
        "What made this time different than other times when you were not as successful?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"];
    }
    public string GetReflectionQuestion()
    {
        int number = _rQuestions.Count();
        Random rand = new Random();
        int r1 = rand.Next(number);
        string question = _rQuestions[r1];
        _rQuestions.RemoveAt(r1);
        return $"Consider the following prompt:\n\n --- " +
        $"Think of a time when you {question} ---";
    }
    public string GetReflection()
    {
        int number = _reflections.Count();
        Random rand = new Random();
        int r1 = rand.Next(number);
        string question = _reflections[r1];
        _reflections.RemoveAt(r1);
        return question;
    }
    public string GetReflectionActivity(int seconds)
    {
        Console.WriteLine(GetReflectionQuestion());
        Console.Write("\nWhen you have something in mind, press enter to continue.\n");
        string answer = Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they are related to this experience.");
        Console.WriteLine(CountdownAnimation());
        Console.Clear();
        List<string> questions = [];
        DateTime endtime = TimeLimit(seconds);
        while (DateTime.Now < endtime)
        {
            string question = GetReflection();
            questions.Add(question);
            Console.Write($">{question} ");
            Console.Write(LoadingAnimation(15));
            Console.Write("\n");
        }
        for (var i = 0; i < questions.Count(); i++)
        {
            _reflections.Add(questions[i]);
        }
        return "";
    }
}