
using System;
using System.Collections.Generic;
using System.Threading;

abstract class MindfulnessActivity
{
    protected string ActivityName;
    protected string Description;
    protected int DurationInSeconds;

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Starting {ActivityName}");
        Console.WriteLine(Description);
        Console.Write("Enter duration in seconds: ");
        DurationInSeconds = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowAnimation();
        RunActivity();
        EndActivity();
    }

    public void EndActivity()
    {
        Console.WriteLine("Good job! You have completed the activity.");
        Console.WriteLine($"Activity: {ActivityName}, Duration: {DurationInSeconds} seconds");
        ShowAnimation();
    }

    protected abstract void RunActivity();

    protected void ShowAnimation()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.Write("."); Thread.Sleep(500);
        }
        Console.WriteLine();
    }
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        ActivityName = "Breathing Activity";
        Description = "This activity will help you relax by guiding you through deep breathing exercises.";
    }

    protected override void RunActivity()
    {
        int remainingTime = DurationInSeconds;
        while (remainingTime > 0)
        {
            Console.WriteLine("Breathe in..."); ShowCountdown(4);
            Console.WriteLine("Breathe out..."); ShowCountdown(4);
            remainingTime -= 8;
        }
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private List<string> Prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> ReflectionQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?"
    };

    public ReflectionActivity()
    {
        ActivityName = "Reflection Activity";
        Description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    protected override void RunActivity()
    {
        Random random = new Random();
        Console.WriteLine(Prompts[random.Next(Prompts.Count)]);
        int remainingTime = DurationInSeconds;
        while (remainingTime > 0)
        {
            Console.WriteLine(ReflectionQuestions[random.Next(ReflectionQuestions.Count)]);
            ShowAnimation();
            remainingTime -= 5;
        }
    }
}

class ListingActivity : MindfulnessActivity
{
    private List<string> Prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?"
    };

    public ListingActivity()
    {
        ActivityName = "Listing Activity";
        Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can.";
    }

    protected override void RunActivity()
    {
        Random random = new Random();
        Console.WriteLine(Prompts[random.Next(Prompts.Count)]);
        Console.WriteLine("You will have some time to list as many things as you can.");
        ShowCountdown(5);
        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(DurationInSeconds);
        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You listed {count} items.");
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    new BreathingActivity().StartActivity();
                    break;
                case 2:
                    new ReflectionActivity().StartActivity();
                    break;
                case 3:
                    new ListingActivity().StartActivity();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
