using System;

public class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public string Mood { get; set; }  // Additional field for mood
    public string Location { get; set; }  // Additional field for location

    public JournalEntry(string prompt, string response, string mood, string location)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now.ToString("yyyy-MM-dd");
        Mood = mood;  // Initialize mood
        Location = location;  // Initialize location
    }

    // Override ToString to represent the entry for CSV
    public override string ToString()
    {
        // Format for CSV: Date, Prompt, Response, Mood, Location
        return $"{Date},\"{Prompt}\",\"{Response}\",\"{Mood}\",\"{Location}\"";
    }
}