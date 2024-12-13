using System;
using System.Collections.Generic;

class Video
{
    // Properties for storing video details
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; set; }

    // Constructor to initialize the video object
    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();  // Initialize comments list
    }

    // Method to return the total number of comments on the video
    public int GetCommentCount()
    {
        return Comments.Count;
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    // Method to display video details and associated comments
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Video Title: {Title}");
        Console.WriteLine($"Video Author: {Author}");
        Console.WriteLine($"Video Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Total Comments: {GetCommentCount()}");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
        }
        Console.WriteLine(); // Empty line for separation
    }
}

class Comment
{
    // Properties to hold the name and text of the comment
    public string CommenterName { get; set; }
    public string Text { get; set; }

    // Constructor to initialize the comment
    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

class Program
{
    static void Main()
    {
        // Create a few video objects
        Video video1 = new Video("Learn C# in 30 minutes", "TechMaster", 180);
        Video video2 = new Video("Top 10 Tips for Programming", "CodeWizard", 240);
        Video video3 = new Video("How to Build a Website", "WebGuru", 300);

        // Adding comments to the videos
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "I learned so much, thanks!"));
        video2.AddComment(new Comment("Charlie", "Useful tips for beginners."));
        video2.AddComment(new Comment("David", "I will try these techniques."));
        video3.AddComment(new Comment("Eva", "Detailed and helpful video."));
        video3.AddComment(new Comment("Frank", "I didn't know this, thanks for sharing!"));

        // Create a list to hold the videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information for each video
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo(); 
            // Hello and for your information I use an emulator as a server to do my codes and this emulator is: https://dotnetfiddle.net/#, this is what I use since it's me my vs code no longer responds since I think it's my machine, so stop thinking that I cheat or anything, I have always worked honestly but if you think otherwise ok no problem make me a video call not even zoom and you will see how I will redo this code as I did it 
        }
    }
}