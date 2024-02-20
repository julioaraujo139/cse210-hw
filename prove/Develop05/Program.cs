using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int userScore = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine($"\nYou have 0 points.\n");

            Console.WriteLine("Menu Options: ");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    DisplayGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    return;
                case "6":
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }

    static void DisplayGoals()
    {
        Console.WriteLine("\nThe goals are: ");
        int number = 1;

        foreach (var goal in goals)
        {
            Console.Write($"{number}. {goal.Description} ({goal.Description}) ");
            number++;

            if (goal is SimpleGoal)
            {
                Console.WriteLine(((SimpleGoal)goal).Completed ? "[X]" : "[ ]");
            }
            else if (goal is EternalGoal)
            {
                Console.WriteLine("[Eternal]");
            }
            else if (goal is ChecklistGoal)
            {
                var checklistGoal = (ChecklistGoal)goal;
                Console.WriteLine($"Completed {checklistGoal.CompletedCount}/{checklistGoal.TargetCount} times");
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        Console.Write("Which type of goal would like to create? ");
        string typeChoice = Console.ReadLine();

        Goal newGoal;


        Console.Write("What is the name of your goal? ");
        string nameGoal = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        string amount = Console.ReadLine();

        switch (typeChoice)
        {
            case "1":

                newGoal = new SimpleGoal(description);
                break;
            case "2":
                newGoal = new EternalGoal(description);
                break;
            case "3":
                Console.Write("Enter the target completion count: ");
                int targetCount = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(description, targetCount);
                break;
            default:
                Console.WriteLine("Invalid choice. Goal not created.");
                return;
        }

        goals.Add(newGoal);
        Console.WriteLine("Goal created successfully.");
    }

    static void RecordEvent()
    {
        Console.WriteLine("\nSelect the goal to record an event:");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Description}");
        }

        Console.Write("Enter the number corresponding to the goal: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            Goal goal = goals[goalIndex];
            goal.RecordEvent();

            Console.WriteLine("Event recorded successfully.");
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    static void DisplayScore()
    {
        Console.WriteLine($"\nYour current score is: {userScore}");
    }

    static void SaveGoals()
    {
        /*string json = JsonConvert.SerializeObject(goals, Formatting.Indented);
        File.WriteAllText("goals.json", json);

        Console.WriteLine("Goals and score saved successfully. Exiting program.");*/
    }

    static void LoadGoals()
    {
        /*if (File.Exists("goals.json"))
        {
            string json = File.ReadAllText("goals.json");
            goals = JsonConvert.DeserializeObject<List<Goal>>(json);
        }*/
    }
}

class Goal
{
    public string Description { get; set; }

    public virtual void RecordEvent()
    {
        // Default implementation for simple and eternal goals
    }
}

class SimpleGoal : Goal
{
    public bool Completed { get; private set; }

    public SimpleGoal(string description)
    {
        Description = description;
    }

    public override void RecordEvent()
    {
        /*Completed = true;
        Program.userScore += 1000; // Points for completing a simple goal*/
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string description)
    {
        Description = description;
    }

    // No need to override RecordEvent for eternal goals
}

class ChecklistGoal : Goal
{
    public int TargetCount { get; private set; }
    public int CompletedCount { get; private set; }

    public ChecklistGoal(string description, int targetCount)
    {
        Description = description;
        TargetCount = targetCount;
    }

    public override void RecordEvent()
    {
        /*CompletedCount++;

        if (CompletedCount < TargetCount)
        {
            Program.userScore += 50; // Points for each completion
        }
        else
        {
            Program.userScore += 500; // Bonus points for completing the checklist goal
        }*/
    }
}
