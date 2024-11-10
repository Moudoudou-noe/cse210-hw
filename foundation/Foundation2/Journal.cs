using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<JournalEntry> Entries { get; private set; }
    private static List<string> Prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public Journal()
    {
        Entries = new List<JournalEntry>();
    }

    public void AddEntry(string response, string mood, string location)
    {
        Random rand = new Random();
        string prompt = Prompts[rand.Next(Prompts.Count)];
        JournalEntry newEntry = new JournalEntry(prompt, response, mood, location);
        Entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        if (Entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal.");
            return;
        }

        foreach (var entry in Entries)
        {
            Console.WriteLine(entry);
        }
    }

    // Save the journal as a CSV file
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            // Write a header for the CSV file
            writer.WriteLine("Date,Prompt,Response,Mood,Location");

            foreach (var entry in Entries)
            {
                writer.WriteLine(entry.ToString());
            }
        }
        Console.WriteLine("Journal saved to file.");
    }

    // Load the journal from a CSV file
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        Entries.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            bool firstLine = true;

            while ((line = reader.ReadLine()) != null)
            {
                if (firstLine)
                {
                    // Skip the header line
                    firstLine = false;
                    continue;
                }

                // Parse the CSV line into components
                string[] parts = line.Split(',');

                if (parts.Length == 5)
                {
                    string date = parts[0];
                    string prompt = parts[1].Trim('"');
                    string response = parts[2].Trim('"');
                    string mood = parts[3].Trim('"');
                    string location = parts[4].Trim('"');
                    Entries.Add(new JournalEntry(prompt, response, mood, location) { Date = date });
                }
            }
        }
        Console.WriteLine("Journal loaded from file.");
    }
}