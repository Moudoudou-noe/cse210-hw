using System;

class Program
{
    static void Main(string[] args)
    {
        var scriptures = new[]
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son"),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding"),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ who strengthens me")
        };

        var random = new Random();
        var scripture = scriptures[random.Next(scriptures.Length)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture);

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden! Congratulations!");
                break;
            }

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit") break;

            scripture.HideRandomWords(3); // Hide three words per iteration
        }
    }
}