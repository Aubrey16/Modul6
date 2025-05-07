using System;
using System.Collections.Generic;

public class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    public string Username { get; private set; }

    public SayaTubeUser(string username)
    {
        // PRECONDITION
        if (string.IsNullOrEmpty(username))
            throw new ArgumentException("Username tidak boleh null atau kosong.");
        if (username.Length > 100)
            throw new ArgumentException("Username maksimal 100 karakter.");

        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.Username = username;
        this.uploadedVideos = new List<SayaTubeVideo>();
    }

    public void AddVideo(SayaTubeVideo video)
    {
        // PRECONDITION
        if (video == null)
            throw new ArgumentNullException("Video tidak boleh null.");
        if (video.GetPlayCount() >= int.MaxValue)
            throw new ArgumentException("Play count video sudah mencapai batas maksimum.");

        this.uploadedVideos.Add(video);
    }

    public int GetTotalVideoPlayCount()
    {
        int total = 0;
        foreach (var video in uploadedVideos)
        {
            total += video.GetPlayCount();
        }
        return total;
    }

    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine($"User: {this.Username}");

        // POSTCONDITION: Print maksimal 8 video
        int limit = Math.Min(8, uploadedVideos.Count);

        for (int i = 0; i < limit; i++)
        {
            Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].GetTitle()}");
        }
    }
}
