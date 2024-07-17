using System;
using System.Collections.Generic;
abstract class Activity
{
    public DateTime Date { get; set; }
    public int Duration { get; set; } 
    public Activity(DateTime date, int duration)
    {
        Date = date;
        Duration = duration;
    }

    public abstract double GetDistance(); 
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{Date.ToShortDateString()} {this.GetType().Name} ({Duration} min): Distance {GetDistance():F2} miles, Speed {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }
}
class Running : Activity
{
    public double Distance { get; set; } 

    public Running(DateTime date, int duration, double distance)
        : base(date, duration)
    {
        Distance = distance;
    }

    public override double GetDistance()
    {
        return Distance;
    }

    public override double GetSpeed()
    {
        return (Distance / Duration) * 60;
    }

    public override double GetPace()
    {
        return Duration / Distance;
    }
}
class Cycling : Activity
{
    public double Speed { get; set; } 

    public Cycling(DateTime date, int duration, double speed)
        : base(date, duration)
    {
        Speed = speed;
    }

    public override double GetDistance()
    {
        return (Speed * Duration) / 60;
    }

    public override double GetSpeed()
    {
        return Speed;
    }

    public override double GetPace()
    {
        return 60 / Speed;
    }
}

class Swimming : Activity
{
    public int Laps { get; set; }
    private const double LapDistance = 50.0 / 1000.0 * 0.62; 

    public Swimming(DateTime date, int duration, int laps)
        : base(date, duration)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * LapDistance;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Duration) * 60;
    }

    public override double GetPace()
    {
        return Duration / GetDistance();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Running run = new Running(new DateTime(2023, 7, 1), 30, 3.0);
        Cycling cycle = new Cycling(new DateTime(2023, 7, 2), 45, 20.0);
        Swimming swim = new Swimming(new DateTime(2023, 7, 3), 60, 40);

        List<Activity> activities = new List<Activity> { run, cycle, swim };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
