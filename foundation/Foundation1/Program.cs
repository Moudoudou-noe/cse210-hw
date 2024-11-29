using System;
using System.Collections.Generic;

class Video
{
    // Properties (attributes)
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; set; } // List to hold comments

    // Constructor to initialize the video
    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>(); // Initialize the list of comments
    }

    // Method to get the number of comments
    public int GetNumberOfComments()
    {
        return Comments.Count; // Returns the count of comments
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        Comments.Add(comment); // Adds a comment to the list
    }
}

class Comment
{
    // Properties (attributes)
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
        // Create some videos
        Video video1 = new Video("Amazing Product Placement", "JohnDoe", 120);
        Video video2 = new Video("Top 10 Products of 2024", "JaneSmith", 180);
        Video video3 = new Video("Product Review: SuperWidget", "TechGuru", 150);

        // Create comments for video1
        video1.AddComment(new Comment("Alice", "This is a great review!"));
        video1.AddComment(new Comment("Bob", "I love this product!"));
        video1.AddComment(new Comment("Charlie", "Very informative, thanks!"));

        // Create comments for video2
        video2.AddComment(new Comment("David", "Interesting list, I learned a lot."));
        video2.AddComment(new Comment("Eva", "I already own a few of these!"));

        // Create comments for video3
        video3.AddComment(new Comment("Frank", "I need this product!"));
        video3.AddComment(new Comment("Grace", "The review was really helpful."));

        // Create a list of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Iterate through the list of videos and display information
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}\n");

            // Display all comments for this video
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine(); // Separate videos with an empty line
        }
    }
}