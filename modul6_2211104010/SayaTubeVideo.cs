using System;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        // PRECONDITION
        if (string.IsNullOrEmpty(title))
            throw new ArgumentException("Judul tidak boleh null atau kosong.");
        if (title.Length > 200)
            throw new ArgumentException("Judul maksimal 200 karakter.");

        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        try
        {
            // PRECONDITION
            if (count < 0)
                throw new ArgumentException("Play count tidak boleh negatif.");
            if (count > 25000000)
                throw new ArgumentException("Maksimal play count yang boleh ditambahkan adalah 25.000.000.");

            // PRECONDITION: Tidak boleh overflow
            if (this.playCount > int.MaxValue - count)
                throw new OverflowException("Penambahan play count menyebabkan overflow.");

            // EXCEPTION HANDLING: gunakan checked untuk deteksi overflow
            checked
            {
                this.playCount += count;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Exception] {ex.Message}");
        }
    }

    public int GetPlayCount()
    {
        return this.playCount;
    }

    public string GetTitle()
    {
        return this.title;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"Video ID: {this.id}");
        Console.WriteLine($"Title: {this.title}");
        Console.WriteLine($"Play Count: {this.playCount}");
    }
}
