using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Journal Program");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to a file (CSV)");
            Console.WriteLine("4. Load journal from a file (CSV)");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter your response:");
                    string response = Console.ReadLine();
                    Console.WriteLine("How did you feel today? (Enter mood)");
                    string mood = Console.ReadLine();
                    Console.WriteLine("Where were you? (Enter location)");
                    string location = Console.ReadLine();
                    journal.AddEntry(response, mood, location);
                    break;

                case "2":
                    journal.DisplayEntries();
                    Console.WriteLine("Press Enter to return to the menu.");
                    Console.ReadLine();
                    break;

                case "3":
                    Console.Write("Enter filename to save journal (e.g., journal.csv): ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    Console.WriteLine("Press Enter to return to the menu.");
                    Console.ReadLine();
                    break;

                case "4":
                    Console.Write("Enter filename to load journal (e.g., journal.csv): ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    Console.WriteLine("Press Enter to return to the menu.");
                    Console.ReadLine();
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}