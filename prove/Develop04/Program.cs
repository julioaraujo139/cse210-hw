using System;
using System.Threading;

// Base class for activity
class MindfulnessActivity
{
    protected string name;
    protected string description;
    protected int duration;

    public MindfulnessActivity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public void StartActivity()
    {
        DisplayStartingMessage();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected virtual void DisplayStartingMessage()
    {
        Console.WriteLine($"\nWelcome to the {name} activity:");
        Console.WriteLine($"\n{description}");
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        duration = int.Parse(Console.ReadLine()); 

        Console.WriteLine("\nGet ready...");
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        foreach (string s in animationStrings)
        {
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        int i = 0;

        List<string> numberStrings = new List<string>();
        numberStrings.Add("4");
        numberStrings.Add("3");
        numberStrings.Add("2");
        numberStrings.Add("1");

        Console.Write("\nBreathe in...");
        Console.Write("\nNow breathe out...\n");
        
        while (DateTime.Now < endTime)
        {
            string n = numberStrings[i];

            Console.Write(n);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;

            if (i >= numberStrings.Count)
            {
                i = 0;
            }
        }
    }

    protected virtual void DisplayEndingMessage()
    {
        Console.WriteLine($"Great job! You have completed the {name} activity for {duration} seconds.");
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        foreach (string s in animationStrings)
        {
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected virtual void PerformActivity()
    {
        // Base implementation for activities       
    }
}

// Breathing activity
class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("\nWell done!!\n");

        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        foreach (string s in animationStrings)
        {
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}

// Reflection activity
class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] reflectionQuestions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Get ready to start reflecting...\n");

        Random random = new Random();

        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);

        foreach (var question in reflectionQuestions)
        {
            Console.WriteLine(question);
            Thread.Sleep(2000); // Pause for 2 seconds
        }
    }
}

// Listing activity
class ListingActivity : MindfulnessActivity
{
    private string[] listingPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Get ready to start listing...\n");

        Random random = new Random();

        string prompt = listingPrompts[random.Next(listingPrompts.Length)];
        Console.WriteLine(prompt);

        Console.WriteLine("Start listing...");
        Thread.Sleep(duration * 1000); // Pause for the specified duration

        Console.WriteLine($"You listed {duration} items.");
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflection activity");
            Console.WriteLine("3. start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");

            int choice = int.Parse(Console.ReadLine());

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    continue;
            }

            activity.StartActivity();
        }
    }
}
