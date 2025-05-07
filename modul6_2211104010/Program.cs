using System;

class Program
{
    static void Main(string[] args)
    {
        SayaTubeUser user = new SayaTubeUser("Aubrey");

        string[] filmTitles =
        {
            "Ripiu Pelem Perang Bintang : Balas Dendam Sith Aubrey",
            "Ripiu Pelem bola : pada gerakan bumi by Aubrey",
            "Ripiu Pelem Takdir : pedang bekerja selamanya by Aubrey",
            "Ripiu Trailer GTA VI by Aubrey ",
            "Ripiu Trailer 2 GTA VI  by Aubrey",
        };

        foreach (string title in filmTitles)
        {
            SayaTubeVideo video = new SayaTubeVideo(title);
            video.IncreasePlayCount(new Random().Next(1, 1000000));
            user.AddVideo(video);
        }

        Console.WriteLine("\n=== Detail Semua Video ===");
        user.PrintAllVideoPlaycount();
        Console.WriteLine($"\nTotal Play Count dari semua video: {user.GetTotalVideoPlayCount()}");
    }
}
