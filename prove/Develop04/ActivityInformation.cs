using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
public class ActivityInfomation : TimedItems
{
    private string _breathingInfo;
    private string _breathingName;
    private string _reflectingInfo;
    private string _reflectingName;
    private string _listingInfo;
    private string _listingName;
 
    public ActivityInfomation(int seconds) : base (seconds)
    {
        _breathingName = "Breathing Activity.";
 
        _reflectingName = "Reflecting Activity.";
 
        _listingName = "Listing Activity.";
 
        _breathingInfo = "This activity will help you relax by walking" +
        " through breathing in and out slowly. Clear your mind and focus" +
        " on your breathing.";
 
        _reflectingInfo = "This activity will help you reflect on times in" +
        " your life when you have shown strength and resilience. This will" +
        " help you recognize the power you have and how you use it in other" +
        " aspects life.";
 
        _listingInfo = "This activity will help you reflect on the good" +
        " things in life by having you list as many things as you can in a" +
        " certain area.";
    }
    public string GetActivity(int selection)
    {
        if (selection == 1)
        {
            return _breathingInfo;
        }
        else if (selection == 2)
        {
            return _reflectingInfo;
        }
        else
        {
            return _listingInfo;
        }
    }
    public string GetActivityName(int selection)
    {
        if (selection == 1)
        {
            return _breathingName;
        }
        else if (selection == 2)
        {
            return _reflectingName;
        }
        else
        {
            return _listingName;
        }
    }
    public string GetActivityStats(string activity, int seconds)
    {
        Console.WriteLine("Well done!!");
        Console.WriteLine(LoadingAnimation(5));
        Console.WriteLine($"You have completed {seconds} seconds of the {activity}");
        Console.WriteLine(LoadingAnimation(5));
        return "";
    }
}