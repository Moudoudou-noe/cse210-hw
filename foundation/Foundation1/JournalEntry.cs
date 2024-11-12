using System;

public class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public string Mood { get; set; }
    public string Location { get; set; }

    public JournalEntry(string prompt, string response, string mood, string location, string date = null)
    {
        Prompt = prompt;
        Response = response;
        Mood = mood;
        Location = location;
        Date = string.IsNullOrEmpty(date) ? DateTime.Now.ToString("yyyy-MM-dd") : date;
    }

    public override string ToString()
    {
        return $"{Date},\"{Prompt}\",\"{Response}\",\"{Mood}\",\"{Location}\"";
    }
}