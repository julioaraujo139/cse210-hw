using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public TimeSpan ScriptureStudyTime { get; set; } // New property for scripture study time

    public string GetFormattedScriptureStudyTime()
    {
        return ScriptureStudyTime.ToString(@"hh\:mm");
    }
}

class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(string prompt, string response, string date, TimeSpan scriptureStudyTime)
    {
        Entry newEntry = new Entry
        {
            Prompt = prompt,
            Response = response,
            Date = date,
            ScriptureStudyTime = scriptureStudyTime
        };
        entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date} - Prompt: {entry.Prompt}\n{entry.Response}");
            Console.WriteLine($"Scripture Study Time: {entry.GetFormattedScriptureStudyTime()}\n");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}|{entry.GetFormattedScriptureStudyTime()}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();
        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        TimeSpan scriptureStudyTime;
                        if (TimeSpan.TryParseExact(parts[3], @"hh\:mm", null, out scriptureStudyTime))
                        {
                            AddEntry(parts[1], parts[2], parts[0], scriptureStudyTime);
                        }
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Creating a new journal.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();

        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "How much time did I spend studying scripture today?" // New prompt for scripture study time
        };

        Console.WriteLine("Welcome to the Journal Program!");

        while (true)
        {
            Console.WriteLine("Please Select one of the following choices: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string randomPrompt = prompts[new Random().Next(prompts.Count)];
                    Console.WriteLine(randomPrompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    string currentDate = DateTime.Now.ToString("MM/dd/yyyy");

                    // Check if the prompt is related to scripture study time
                    if (randomPrompt.ToLower().Contains("scripture"))
                    {
                        Console.Write("How much time did you spend studying scripture (hh:mm)? ");
                        string studyTimeInput = Console.ReadLine();
                        TimeSpan scriptureStudyTime;

                        // Parse the scripture study time input
                        if (TimeSpan.TryParseExact(studyTimeInput, @"hh\:mm", null, out scriptureStudyTime))
                        {
                            myJournal.AddEntry(randomPrompt, response, currentDate, scriptureStudyTime);
                        }
                        else
                        {
                            Console.WriteLine("Invalid time format. Entry not recorded.");
                        }
                    }
                    else
                    {
                        myJournal.AddEntry(randomPrompt, response, currentDate, TimeSpan.Zero);
                    }
                    break;

                case "2":
                    myJournal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("What is the filename?\n");
                    string loadFilename = Console.ReadLine();
                    myJournal.LoadFromFile(loadFilename);
                    break;

                case "4":
                    Console.Write("What is the filename?\n");
                    string saveFilename = Console.ReadLine();
                    myJournal.SaveToFile(saveFilename);
                    break;
                
                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please choose a number from 1 to 5.");
                    break;
            }
        }
    }
}
