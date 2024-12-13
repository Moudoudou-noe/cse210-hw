using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }

    public Goal(string name, string description)
    {
        Name = name;
        Description = description;
        IsComplete = false;
    }

    public abstract void RecordEvent();
    public abstract string GetDetailsString();
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description)
    {
        Points = points;
    }

    public override void RecordEvent()
    {
        if (!IsComplete)
        {
            IsComplete = true;
            Points = 1000; // Example points for completion
            Console.WriteLine($"Goal '{Name}' completed! You earned {Points} points.");
        }
    }

    public override string GetDetailsString()
    {
        return $"{Name} - {Description} - {(IsComplete ? "Completed" : "Not Completed")}";
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, string description)
        : base(name, description)
    {
        Points = 100; // Example points for each event recorded
    }

    public override void RecordEvent()
    {
        Points += 100; // Earn points each time an event is recorded
        Console.WriteLine($"You earned {Points} points for '{Name}'!");
    }

    public override string GetDetailsString()
    {
        return $"{Name} - {Description} - Ongoing (Points: {Points})";
    }
}

class ChecklistGoal : Goal
{
    public int Target { get; set; }
    public int Completed { get; set; }

    public ChecklistGoal(string name, string description, int target)
        : base(name, description)
    {
        Target = target;
        Completed = 0;
    }

    public override void RecordEvent()
    {
        if (Completed < Target)
        {
            Completed++;
            Points += 50; // Points for each completion
            Console.WriteLine($"You completed part of the checklist goal. Total completions: {Completed}/{Target}");
        }

        if (Completed == Target)
        {
            Points += 500; // Bonus points for completing the checklist
            Console.WriteLine($"Congratulations! You completed the goal and earned {Points} points.");
        }
    }

    public override string GetDetailsString()
    {
        return $"{Name} - {Description} - Completed {Completed}/{Target}";
    }
}

class Program
{
    static List<Goal> goals = new List<Goal>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nEternal Quest Program\n");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Event for a Goal");
            Console.WriteLine("3. View Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");

            Console.Write("Select an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ViewGoals();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    return;
            }
        }
    }

    static void CreateNewGoal()
    {
        Console.WriteLine("Enter the type of goal (simple, eternal, checklist): ");
        string type = Console.ReadLine();

        Console.WriteLine("Enter the name of the goal: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter a description for the goal: ");
        string description = Console.ReadLine();

        if (type.ToLower() == "simple")
        {
            goals.Add(new SimpleGoal(name, description, 1000));
        }
        else if (type.ToLower() == "eternal")
        {
            goals.Add(new EternalGoal(name, description));
        }
        else if (type.ToLower() == "checklist")
        {
            Console.WriteLine("Enter the target number of completions for the checklist goal: ");
            int target = int.Parse(Console.ReadLine());
            goals.Add(new ChecklistGoal(name, description, target));
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    static void RecordEvent()
    {
        Console.WriteLine("Enter the name of the goal to record an event for: ");
        string goalName = Console.ReadLine();

        Goal goal = goals.Find(g => g.Name.Equals(goalName, StringComparison.OrdinalIgnoreCase));
        if (goal != null)
        {
            goal.RecordEvent();
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    static void ViewGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    static void SaveGoals()
    {
        using (StreamWriter file = new StreamWriter("goals.txt"))
        {
            foreach (var goal in goals)
            {
                file.WriteLine($"{goal.Name},{goal.Description},{goal.Points},{goal.IsComplete}");
            }
        }
        Console.WriteLine("Goals saved.");
    }

    static void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            using (StreamReader file = new StreamReader("goals.txt"))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    // This part is simplified; would need to re-create goal objects based on file data
                    Console.WriteLine($"Loaded Goal: {parts[0]}");
                }
            }
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }
}