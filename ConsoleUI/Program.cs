using ConsoleUI.Models;
using ConsoleUI.WithGenerics;
using ConsoleUI.WithoutGenerics;

Console.WriteLine();
Console.WriteLine("Press enter to shut down");

// here T allows to specify which type this list is about
List<int> ages = new List<int> { 1, 2, 3 };
ages.Add(3);
 
Console.WriteLine(" ** Without Generics **");
DemonstrateTextFileStorage();


static void DemonstrateTextFileStorage()
{
    List<Person> people = new List<Person>();
    List<LogEntry> logs= new List<LogEntry>();

    string peopleFile = @"C:\Temp\people.csv";
    string logFile = @"C:\Temp\logs.csv";

    PopulateLists(people, logs);

    //OriginalTextFileProcessor.SavePeople(people, peopleFile);
    //var newPeople = OriginalTextFileProcessor.LoadPeople(peopleFile);

    //foreach (var p in newPeople)
    //{
    //    Console.WriteLine($" { p.FirstName } { p.LastName } (IsAlive = { p.IsAlive }");
    //}

    //OriginalTextFileProcessor.SaveLogs(logs, logFile);

    //var newLogs = OriginalTextFileProcessor.LoadLogs(logFile);

    //foreach (var log in newLogs)
    //{
    //    Console.WriteLine($" { log.ErrorCode } : { log.Message } at {log.TimeOfEvent.ToShortTimeString()}");
    //}

    // Using Generics
    Console.WriteLine(" ** Using Generics **");

    GenericTextFileProcessor.SaveToTextFile<Person>(people, peopleFile);
    GenericTextFileProcessor.SaveToTextFile<LogEntry>(logs, logFile);

    var newPeople2 = GenericTextFileProcessor.LoadFromTextFile<Person>(peopleFile);

    foreach (var p in newPeople2)
    {
        Console.WriteLine($" { p.FirstName } { p.LastName } (IsAlive = { p.IsAlive }");
    }

    var newLogs2 = GenericTextFileProcessor.LoadFromTextFile<LogEntry>(logFile);

    foreach (var log in newLogs2)
    {
        Console.WriteLine($" { log.ErrorCode } : { log.Message } at {log.TimeOfEvent.ToShortTimeString()}");
    }

}


static void PopulateLists(List<Person> people, List<LogEntry> logs)
{
    people.Add(new Person { FirstName = "Tim", LastName = "Corey" });
    people.Add(new Person { FirstName = "Sue", LastName = "Storm", IsAlive = false });
    people.Add(new Person { FirstName = "Greg", LastName = "Olsen" });

    logs.Add(new LogEntry { Message = "I blew up", ErrorCode = 999 });
    logs.Add(new LogEntry { Message = "I'm too awesome", ErrorCode = 1337 });
    logs.Add(new LogEntry { Message = "I was tired", ErrorCode = 2222 });

}


Console.ReadLine();