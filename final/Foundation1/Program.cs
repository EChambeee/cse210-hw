using System;
using System.Collections.Generic;

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }

    public override string ToString()
    {
        return $"{Name}: {Text}";
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentsCount()
    {
        return Comments.Count;
    }

    public override string ToString()
    {
        string commentsStr = string.Join("\n", Comments);
        return $"Title: {Title}\nAuthor: {Author}\nLength: {Length} seconds\nNumber of Comments: {GetCommentsCount()}\nComments:\n{commentsStr}\n";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Learning Python", "John Doe", 300);
        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "Very informative."));
        video1.AddComment(new Comment("Charlie", "Helped me a lot, thanks!"));

        Video video2 = new Video("Cooking Pasta", "Jane Smith", 600);
        video2.AddComment(new Comment("Dave", "Yummy!"));
        video2.AddComment(new Comment("Eve", "I love pasta."));

        Video video3 = new Video("Travel Vlog", "Emily Johnson", 1200);
        video3.AddComment(new Comment("Frank", "Beautiful places!"));
        video3.AddComment(new Comment("Grace", "Amazing vlog!"));
        video3.AddComment(new Comment("Heidi", "Can't wait to visit."));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            Console.WriteLine(video);
        }
    }
}
