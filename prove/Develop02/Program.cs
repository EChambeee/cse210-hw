using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What new thing did I learn today?",
        "What is one thing I am grateful for today?",
        "Describe a moment that made you laugh today.",
        "What challenge did I overcome today?",
        "What is one goal I achieved today?"
    };

    static List<JournalEntry> journalEntries = new List<JournalEntry>();

    class JournalEntry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }
    }

    static void ShowRandomPrompt()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        journalEntries.Add(new JournalEntry
        {
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            Prompt = prompt,
            Response = response
        });
        Console.WriteLine("Entry saved.");
    }

    static void DisplayJournal()
    {
        if (journalEntries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
        }
        else
        {
            foreach (var entry in journalEntries)
            {
                Console.WriteLine($"Date: {entry.Date}");
                Console.WriteLine($"Prompt: {entry.Prompt}");
                Console.WriteLine($"Response: {entry.Response}");
                Console.WriteLine(new string('-', 40));
            }
        }
    }

    static void SaveJournalToFile()
    {
        Console.Write("Enter the filename to save the journal: ");
        string filename = Console.ReadLine();
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(journalEntries, options);
        File.WriteAllText(filename, json);
        Console.WriteLine("Journal saved to file.");
    }

    static void LoadJournalFromFile()
    {
        Console.Write("Enter the filename to load the journal: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            journalEntries = JsonSerializer.Deserialize<List<JournalEntry>>(json);
            Console.WriteLine("Journal loaded from file.");
        }
        else
        {
            Console.WriteLine("File not found. Please check the filename and try again.");
        }
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");

            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowRandomPrompt();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    SaveJournalToFile();
                    break;
                case "4":
                    LoadJournalFromFile();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}
