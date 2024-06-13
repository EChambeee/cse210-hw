public class TimedItems
{
    private int _seconds;
    private List<string> _animation;
 
    public TimedItems(int seconds)
    {
        _seconds = seconds;
        _animation = ["/","-","\\","|"];
    }
    public DateTime TimeLimit(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        return endTime;
    }
    public string LoadingAnimation(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = _animation[i];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
            if (i >= _animation.Count)
            {
                i = 0;
            }
        }
        return "";
    }
    public string CountdownAnimation()
    {
        Console.Write("You may begin in: ");
        for (int i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        return "";
    }
}