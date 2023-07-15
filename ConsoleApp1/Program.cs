using System;
using System.IO;
using System.Text;

[Serializable]
public class Event
{
    public int EventNumber { get; set; }
    public string Location { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Step 2: Create an object from the Event class and assign values
        Event myEvent = new Event
        {
            EventNumber = 1,
            Location = "Calgary"
        };

        // Step 3: Serialize the object to a file
        SerializeObjectToFile(myEvent, "event.txt");

        // Step 4: Deserialize the object from the file and display the values
        Event deserializedEvent = DeserializeObjectFromFile("event.txt");
        Console.WriteLine(deserializedEvent.EventNumber);
        Console.WriteLine(deserializedEvent.Location);

        // Step 5: Read from the file and display first, middle, and last characters
        ReadFromFile();

        // Prevent the program from exiting immediately
        Console.Read();
    }

    // Serialize the object to a file
    static void SerializeObjectToFile(Event obj, string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(obj.EventNumber);
            writer.WriteLine(obj.Location);
        }
    }

    // Deserialize the object from the file
    static Event DeserializeObjectFromFile(string fileName)
    {
        Event obj = new Event();
        using (StreamReader reader = new StreamReader(fileName))
        {
            obj.EventNumber = int.Parse(reader.ReadLine());
            obj.Location = reader.ReadLine();
        }
        return obj;
    }

    // Method to read and manipulate the file
    static void ReadFromFile()
    {
        string fileName = "event.txt";

        // Write "Hackathon" to the file
        File.WriteAllText(fileName, "Hackathon");

        // Read the first, middle, and last characters from the file
        string content = File.ReadAllText(fileName);
        int firstCharacter = content[0];
        int middleCharacter = content[content.Length / 2];
        int lastCharacter = content[content.Length - 1];

        Console.WriteLine("In Word: Hackathon");
        Console.WriteLine($"The First Character is: \"{(char)firstCharacter}\"");
        Console.WriteLine($"The Middle Character is: \"{(char)middleCharacter}\"");
        Console.WriteLine($"The Last Character is: \"{(char)lastCharacter}\"");
    }
}
