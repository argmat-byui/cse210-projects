using System;

class Program
{
    static void Main(string[] args)
    {
        Address address = new Address("Av. Pedro Simón Laplace 5637", "Córdoba", "Córdoba", "Argentina");
        Lecture lecture = new Lecture("MyLecture", "My cool lecture description.", new DateOnly(2024, 6, 20), new TimeOnly(11, 0), address, "John Smith", 85);
        Reception reception  = new Reception("MyReception", "My cool reception description.", new DateOnly(2025, 7, 21), new TimeOnly(12, 20), address, "rsvpemail@domain.com");
        OutdoorGathering outdoorGathering  = new OutdoorGathering("MyOutdoorGathering", "My cool outdoor gathering description.", new DateOnly(2024, 8, 10), new TimeOnly(8, 30), address, "Partly cloudy");
        List<Event> events = [lecture, reception, outdoorGathering];
        string separationLine = "******************************************************";
        foreach(Event e in events)
        {
            Console.WriteLine("\n");
            Console.WriteLine(separationLine);
            Console.WriteLine(separationLine);
            Console.WriteLine(separationLine);
            Console.WriteLine($"\n\nEvent type: {e.GetTypeOfEvent()}\n");
            Console.WriteLine("Short Description:");
            Console.WriteLine(separationLine);
            Console.WriteLine(e.GetShortDescription());
            Console.WriteLine(separationLine);
            Console.WriteLine("Full Details:");
            Console.WriteLine(separationLine);
            Console.WriteLine(e.GetFullDetailsMessage());
            Console.WriteLine(separationLine);
            Console.WriteLine("\n\nStandard Details:");
            Console.WriteLine(separationLine);
            Console.WriteLine(e.GetStandardDetailsMessage());
            Console.WriteLine(separationLine);
        }
    }
}