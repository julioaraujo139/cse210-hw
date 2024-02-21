using System;

class Activity
{
    public string Date { get; }
    public int Duration { get; }

    public Activity(string date, int duration)
    {
        Date = date;
        Duration = duration;
    }

    public virtual double GetDistance()
    {
        return 0; 
    }

    public virtual double GetSpeed()
    {
        return 0; 
    }

    public virtual double GetPace()
    {
        return 0; 
    }

    public string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        string summary = $"{Date} {GetType().Name} ({Duration} min) - ";
        summary += $"Distance: {distance:F2} miles, Speed: {speed:F2} mph, Pace: {pace:F2} min per mile";

        return summary;
    }
}

class Running : Activity
{
    public double Distance { get; }

    public Running(string date, int duration, double distance)
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
        return Distance / Duration * 60;
    }

    public override double GetPace()
    {
        return Duration / Distance;
    }
}

class StationaryBicycle : Activity
{
    public double Speed { get; }

    public StationaryBicycle(string date, int duration, double speed)
        : base(date, duration)
    {
        Speed = speed;
    }

    public override double GetDistance()
    {
        return Speed * Duration / 60;
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
    public int Laps { get; }

    public Swimming(string date, int duration, int laps)
        : base(date, duration)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * 50 / 1000 * 0.62;
    }

    public override double GetSpeed()
    {
        return (Laps * 50 / 1000) / Duration * 60;
    }

    public override double GetPace()
    {
        return Duration / (Laps * 50 / 1000);
    }
}

class Program
{
    static void Main()
    {
        Activity[] activities = {
            new Running("03 May 2023", 34, 3.0),
            new StationaryBicycle("12 Jul 2023", 25, 15),
            new Swimming("25 Nov 2023", 37, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
