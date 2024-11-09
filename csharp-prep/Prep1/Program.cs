using System;

class Program
{
    static void Main(string[] args)
    {
        // Step 1: Display welcome message
        DisplayWelcome();

        // Step 2: Prompt user for their name
        string userName = PromptUserName();

        // Step 3: Prompt user for their favorite number
        int favoriteNumber = PromptUserNumber();

        // Step 4: Square the favorite number
        int squaredNumber = SquareNumber(favoriteNumber);

        // Step 5: Display the result
        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }
    
    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
    }
}