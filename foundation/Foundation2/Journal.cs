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

    public void AddEntry(string response, string mood, string location, string date = null)
    {
        if (string.IsNullOrWhiteSpace(response) || string.IsNullOrWhiteSpace(mood) || string.IsNullOrWhiteSpace(location))
        {
            Console.WriteLine("Error: Response, Mood, and Location must not be empty.");
            return;
        }

        Random rand = new Random();
        string prompt = Prompts[rand.Next(Prompts.Count)];
        JournalEntry newEntry = new JournalEntry(prompt, response, mood, location, date);
        Entries.Add(newEntry);
        Console.WriteLine("New entry added successfully.");
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

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine("Date,Prompt,Response,Mood,Location");
                foreach (var entry in Entries)
                {
                    writer.WriteLine(entry.ToString());
                }
            }
            Console.WriteLine("Journal saved to file.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            Entries.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                bool firstLine = true;

                while ((line = reader.ReadLine()) != null)
                {
                    if (firstLine)
                    {
                        firstLine = false;  // Skip the header line
                        continue;
                    }

                    string[] parts = line.Split(',');

                    if (parts.Length == 5)
                    {
                        string date = parts[0];
                        string prompt = parts[1].Trim('"');
                        string response = parts[2].Trim('"');
                        string mood = parts[3].Trim('"');
                        string location = parts[4].Trim('"');
                        Entries.Add(new JournalEntry(prompt, response, mood, location, date));
                    }
                }
            }
            Console.WriteLine("Journal loaded from file.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error loading from file: {ex.Message}");
        }
    }
}