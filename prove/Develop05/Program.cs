using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public abstract class Goal
{
    public string Description { get; set; }
    public int Points { get; set; }
    public bool Completed { get; set; }

    protected Goal(string description, int points)
    {
        Description = description;
        Points = points;
        Completed = false;
    }

    public abstract int RecordEvent();
    public abstract string Display();
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string description, int points) : base(description, points) { }

    public override int RecordEvent()
    {
        if (!Completed)
        {
            Completed = true;
            return Points;
        }
        return 0;
    }

    public override string Display()
    {
        string status = Completed ? "[X]" : "[ ]";
        return $"{status} {Description} (Points: {Points})";
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string description, int points) : base(description, points) { }

    public override int RecordEvent()
    {
        return Points;
    }

    public override string Display()
    {
        return $"[∞] {Description} (Points per record: {Points})";
    }
}

public class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; }
    public int BonusPoints { get; set; }

    public ChecklistGoal(string description, int points, int targetCount, int bonusPoints)
        : base(description, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        BonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            if (CurrentCount == TargetCount)
            {
                Completed = true;
                return Points + BonusPoints;
            }
            return Points;
        }
        return 0;
    }

    public override string Display()
    {
        string status = Completed ? "[X]" : "[ ]";
        return $"{status} {Description} (Completed {CurrentCount}/{TargetCount} times, Points: {Points}, Bonus: {BonusPoints})";
    }
}

public class GoalManager
{
    public List<Goal> Goals { get; set; }
    public int Score { get; set; }

    public GoalManager()
    {
        Goals = new List<Goal>();
        Score = 0;
    }

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < Goals.Count)
        {
            int points = Goals[goalIndex].RecordEvent();
            Score += points;
        }
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < Goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Goals[i].Display()}");
        }
    }

    public void SaveGoals(string filename)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var data = new
        {
            Goals = Goals,
            Score = Score
        };
        File.WriteAllText(filename, JsonSerializer.Serialize(data, options));
    }

    public void LoadGoals(string filename)
    {
        var data = JsonSerializer.Deserialize<dynamic>(File.ReadAllText(filename));
        Score = data.GetProperty("Score").GetInt32();
        Goals.Clear();

        foreach (var goalData in data.GetProperty("Goals").EnumerateArray())
        {
            string type = goalData.GetProperty("Type").GetString();
            string description = goalData.GetProperty("Description").GetString();
            int points = goalData.GetProperty("Points").GetInt32();
            Goal goal = null;

            switch (type)
            {
                case "SimpleGoal":
                    goal = new SimpleGoal(description, points);
                    break;
                case "EternalGoal":
                    goal = new EternalGoal(description, points);
                    break;
                case "ChecklistGoal":
                    int targetCount = goalData.GetProperty("TargetCount").GetInt32();
                    int bonusPoints = goalData.GetProperty("BonusPoints").GetInt32();
                    goal = new ChecklistGoal(description, points, targetCount, bonusPoints);
                    break;
            }

            if (goal != null)
            {
                Goals.Add(goal);
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("\n1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("The types of Goals are (simple, eternal, checklist): ");
                    string goalType = Console.ReadLine().ToLower();
                    Console.Write("Enter goal description: ");
                    string description = Console.ReadLine();
                    Console.Write("Enter points: ");
                    int points = int.Parse(Console.ReadLine());

                    Goal goal = null;
                    if (goalType == "simple")
                    {
                        goal = new SimpleGoal(description, points);
                    }
                    else if (goalType == "eternal")
                    {
                        goal = new EternalGoal(description, points);
                    }
                    else if (goalType == "checklist")
                    {
                        Console.Write("Enter target count: ");
                        int targetCount = int.Parse(Console.ReadLine());
                        Console.Write("Enter bonus points: ");
                        int bonusPoints = int.Parse(Console.ReadLine());
                        goal = new ChecklistGoal(description, points, targetCount, bonusPoints);
                    }

                    if (goal != null)
                    {
                        manager.AddGoal(goal);
                    }
                    else
                    {
                        Console.WriteLine("Invalid goal type.");
                    }
                    break;

                case "2":
                    manager.DisplayGoals();
                    Console.Write("Enter goal number to record event: ");
                    int goalIndex = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordEvent(goalIndex);
                    break;

                case "3":
                    manager.DisplayGoals();
                    break;

                case "4":
                    Console.WriteLine($"Total Score: {manager.Score}");
                    break;

                case "5":
                    Console.Write("Enter filename to save goals: ");
                    string saveFilename = Console.ReadLine();
                    manager.SaveGoals(saveFilename);
                    break;

                case "6":
                    Console.Write("Enter filename to load goals: ");
                    string loadFilename = Console.ReadLine();
                    manager.LoadGoals(loadFilename);
                    break;

                case "7":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
