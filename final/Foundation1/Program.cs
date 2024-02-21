class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> Comments { get; set; } = new List<Comment>();

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");

        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.Name}: {comment.Text}");
        }

        Console.WriteLine();
    }
}

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }
}
class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();
        Video video1 = new Video { Title = "How Do I Get C# Work Experience? How Do I Get My First Job?", Author = "IAmTimCorey", LengthInSeconds = 866 };
        video1.AddComment(new Comment { Name = "navidkh23", Text = "Awesome video. Thank you! Please film new video about: First start to  open-source project." });
        video1.AddComment(new Comment { Name = "nafiscastle", Text = "Thank you for the valuable words." });
        video1.AddComment(new Comment { Name = "simonsholman", Text = "Your green screen setup is awesome. Would love to see a video on your setup." });
        videos.Add(video1);
        Video video2 = new Video { Title = "What Are Some Resume Tips for A C# Developer?", Author = "Ninja239", LengthInSeconds = 728 };
        video2.AddComment(new Comment { Name = "kaiosrun18", Text = "I learned new things." });
        video2.AddComment(new Comment { Name = "Guiwrite", Text = "I love it." });
        video2.AddComment(new Comment { Name = "ssunilust14", Text = "Thx for the video!! Would definitely want to see your recommendation on practising presentation delivery." });
        videos.Add(video2);
        Video video3 = new Video { Title = "What Are Some Tips for Great Presentation?", Author = "jsdeveloper", LengthInSeconds = 1235 };
        video3.AddComment(new Comment { Name = "ngochieungo8819", Text = "the whole tNice tutorialng but then you have a solid foundation." });
        video3.AddComment(new Comment { Name = "OBabchenko", Text = "Great topic and tips on it! Thank you!." });
        video3.AddComment(new Comment { Name = "jamessun", Text = "Solid information all the way around." });
        video3.AddComment(new Comment { Name = "elanisousa", Text = "first.. good points." });
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.DisplayDetails();
        }
    }
}
