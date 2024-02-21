using System;

// Address class to store event addresses
public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    public override string ToString()
    {
        return $"{Street}, {City}, {State} {ZipCode}";
    }
}

// Base Event class
public class Event
{
    private string eventTitle;
    private string eventDescription;
    private DateTime eventDate;
    private TimeSpan eventTime;
    private Address eventAddress;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        eventTitle = title;
        eventDescription = description;
        eventDate = date;
        eventTime = time;
        eventAddress = address;
    }

    public string GetStandardDetails()
    {
        return $"{eventTitle}\n{eventDescription}\nDate: {eventDate.ToShortDateString()}\nTime: {eventTime.ToString(@"hh\:mm")}\nAddress: {eventAddress}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public string GetShortDescription()
    {
        return $"{GetType().Name}: {eventTitle}\nDate: {eventDate.ToShortDateString()}";
    }
}

// Lecture class derived from Event
public class Lecture : Event
{
    private string speakerName;
    private int capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        speakerName = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nSpeaker: {speakerName}\nCapacity: {capacity}";
    }
}

// Reception class derived from Event
public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string email)
        : base(title, description, date, time, address)
    {
        rsvpEmail = email;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nRSVP Email: {rsvpEmail}";
    }
}

// OutdoorGathering class derived from Event
public class OutdoorGathering : Event
{
    private string weatherStatement;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weather)
        : base(title, description, date, time, address)
    {
        weatherStatement = weather;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nWeather: {weatherStatement}";
    }
}

class Program
{
    static void Main()
    {
        // Create instances of each type of event
        Address address1 = new Address { Street = "Guaruja St", City = "Curitiba", State = "Parana", ZipCode = "83405-304" };
        Address address2 = new Address { Street = "Harry Feeken St", City = "Sao Jose dos Pinhais", State = "Parana", ZipCode = "81203-439" };
        Address address3 = new Address { Street = "Hatur Lila St", City = "Colombo", State = "Parana", ZipCode = "82304-450" };

        Lecture lectureEvent = new Lecture("Tech Talk", "Exciting tech topics", DateTime.Now.AddDays(14), new TimeSpan(14, 30, 0), address1, "John Doe", 100);

        Reception receptionEvent = new Reception("Networking Mixer", "Connect and network", DateTime.Now.AddDays(21), new TimeSpan(18, 0, 0), address2, "rsvp@example.com");

        OutdoorGathering outdoorEvent = new OutdoorGathering("Community Picnic", "Fun in the sun", DateTime.Now.AddDays(30), new TimeSpan(12, 0, 0), address3, "Sunny with a chance of clouds");

        // Generate and output marketing messages for each event
        Console.WriteLine("Standard Details:");
        Console.WriteLine(lectureEvent.GetStandardDetails());
        Console.WriteLine();

        Console.WriteLine("Full Details:");
        Console.WriteLine(lectureEvent.GetFullDetails());
        Console.WriteLine();

        Console.WriteLine("Short Description:");
        Console.WriteLine(lectureEvent.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Standard Details:");
        Console.WriteLine(receptionEvent.GetStandardDetails());
        Console.WriteLine();

        Console.WriteLine("Full Details:");
        Console.WriteLine(receptionEvent.GetFullDetails());
        Console.WriteLine();

        Console.WriteLine("Short Description:");
        Console.WriteLine(receptionEvent.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Standard Details:");
        Console.WriteLine(outdoorEvent.GetStandardDetails());
        Console.WriteLine();

        Console.WriteLine("Full Details:");
        Console.WriteLine(outdoorEvent.GetFullDetails());
        Console.WriteLine();

        Console.WriteLine("Short Description:");
        Console.WriteLine(outdoorEvent.GetShortDescription());
    }
}
