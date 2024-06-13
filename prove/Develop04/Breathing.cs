public class Breathing : TimedItems
{
    private int _breatheIN;
    private int _breatheOUT;
 
    public Breathing(int seconds) : base (seconds)
    {
        _breatheIN = 4;
        _breatheOUT = 6;
    }
    public string BreathingIN()
    {
        Console.Write("Breathe in... ");
        for (int i = _breatheIN; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        return "";
    }
    public string BreathingOUT()
    {
        Console.Write("Breathe out... ");
        for (int i = _breatheOUT; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        return "";
    }
    public string GetBreathingActivity(int seconds)
    {
        DateTime endtime = TimeLimit(seconds);
        while (DateTime.Now < endtime)
        {
            Console.WriteLine("");
            Console.WriteLine(BreathingIN());
            Console.WriteLine(BreathingOUT());
        }
        return "";
    }
}