
using System;
using System.Collections.Generic;

namespace FitnessCenterApp
{
    // Base class Activity that contains common properties
    public abstract class Activity
    {
        private DateTime date;
        private int durationInMinutes;

        // Constructor to initialize common properties
        public Activity(DateTime date, int durationInMinutes)
        {
            this.date = date;
            this.durationInMinutes = durationInMinutes;
        }

        // Public property to access durationInMinutes
        public int DurationInMinutes => durationInMinutes;

        // Abstract methods to be overridden by derived classes
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        // Method to get the summary for the activity
        public string GetSummary()
        {
            return $"{date.ToString("dd MMM yyyy")} {this.GetType().Name} ({DurationInMinutes} min): " +
                   $"Distance {GetDistance()} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} min per mile";
        }
    }

    // Derived class for Running activity
    public class Running : Activity
    {
        private double distance; // in miles

        // Constructor to initialize running activity
        public Running(DateTime date, int durationInMinutes, double distance) : base(date, durationInMinutes)
        {
            this.distance = distance;
        }

        // Override GetDistance for Running
        public override double GetDistance()
        {
            return distance;
        }

        // Override GetSpeed for Running
        public override double GetSpeed()
        {
            return (distance / DurationInMinutes) * 60;
        }

        // Override GetPace for Running
        public override double GetPace()
        {
            return DurationInMinutes / distance;
        }
    }

    // Derived class for Cycling activity
    public class Cycling : Activity
    {
        private double speed; // in mph

        // Constructor to initialize cycling activity
        public Cycling(DateTime date, int durationInMinutes, double speed) : base(date, durationInMinutes)
        {
            this.speed = speed;
        }

        // Override GetDistance for Cycling
        public override double GetDistance()
        {
            return (speed * DurationInMinutes) / 60;
        }

        // Override GetSpeed for Cycling
        public override double GetSpeed()
        {
            return speed;
        }

        // Override GetPace for Cycling
        public override double GetPace()
        {
            return 60 / speed;
        }
    }

    // Derived class for Swimming activity
    public class Swimming : Activity
    {
        private int laps; // number of laps

        // Constructor to initialize swimming activity
        public Swimming(DateTime date, int durationInMinutes, int laps) : base(date, durationInMinutes)
        {
            this.laps = laps;
        }

        // Override GetDistance for Swimming
        public override double GetDistance()
        {
            return (laps * 50.0) / 1000; // 50 meters per lap, convert to kilometers
        }

        // Override GetSpeed for Swimming
        public override double GetSpeed()
        {
            return (GetDistance() / DurationInMinutes) * 60; // km per hour
        }

        // Override GetPace for Swimming
        public override double GetPace()
        {
            return DurationInMinutes / GetDistance();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of activities
            List<Activity> activities = new List<Activity>
            {
                new Running(new DateTime(2022, 11, 3), 30, 3.0),
                new Cycling(new DateTime(2022, 11, 3), 30, 12.0),
                new Swimming(new DateTime(2022, 11, 3), 30, 40)
            };

            // Display the summary of each activity
            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}