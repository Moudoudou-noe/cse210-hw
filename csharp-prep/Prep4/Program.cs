using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for the grade percentage
        Console.Write("Enter your grade percentage: ");
        string userInput = Console.ReadLine();
        int gradePercentage = int.Parse(userInput);
        
        string letter = "";
        string sign = "";
        
        // Determine the letter grade
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign for grades A, B, and C
        if (letter != "F") // No signs for F
        {
            int lastDigit = gradePercentage % 10;

            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        
        // Handle A+ and F cases
        if (letter == "A" && sign == "+")
        {
            sign = ""; // No A+ grade
        }
        else if (letter == "F")
        {
            sign = ""; // No F+ or F- grades
        }

        // Display the letter grade with sign
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // Check if the user passed
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Don't worry, keep trying for next time!");
        }
    }
}