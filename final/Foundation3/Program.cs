using System;
using System.Collections.Generic;
class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }
}
class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Time { get; set; }
    public Address Address { get; set; }

    public Event(string title, string description, DateTime date, string time, Address address)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        Address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nAddress: {Address}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails() + $"\nEvent Type: {this.GetType().Name}";
    }

    public virtual string GetShortDescription()
    {
        return $"Type: {this.GetType().Name}\nTitle: {Title}\nDate: {Date.ToShortDateString()}";
    }
}
class Lecture : Event
{
    public string Speaker { get; set; }
    public int Capacity { get; set; }

    public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        Speaker = speaker;
        Capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nSpeaker: {Speaker}\nCapacity: {Capacity}";
    }
}
class Reception : Event
{
    public string RsvpEmail { get; set; }

    public Reception(string title, string description, DateTime date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        RsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nRSVP Email: {RsvpEmail}";
    }
}
class OutdoorGathering : Event
{
    public string Weather { get; set; }

    public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weather)
        : base(title, description, date, time, address)
    {
        Weather = weather;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nWeather: {Weather}";
    }
}
class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Elm St", "Los Angeles", "CA", "USA");
        Address address3 = new Address("789 Oak St", "Chicago", "IL", "USA");

        Lecture lecture = new Lecture("Tech Talk", "A talk on the latest tech trends", new DateTime(2023, 7, 15), "10:00 AM", address1, "Jane Doe", 100);
        Reception reception = new Reception("Networking Event", "An event to network with professionals", new DateTime(2023, 8, 10), "6:00 PM", address2, "rsvp@example.com");
        OutdoorGathering gathering = new OutdoorGathering("Summer Picnic", "A fun outdoor picnic", new DateTime(2023, 9, 5), "12:00 PM", address3, "Sunny");

        List<Event> events = new List<Event> { lecture, reception, gathering };

        foreach (var eventItem in events)
        {
            Console.WriteLine(eventItem.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(eventItem.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(eventItem.GetShortDescription());
            Console.WriteLine(new string('-', 50));
        }
    }
}
