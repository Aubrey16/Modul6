using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // PRECONDITION: username tidak null dan <= 100
            SayaTubeUser user = new SayaTubeUser("Aubrey");

            string[] filmTitles =
            {
                "Ripiu Pelem Perang Bintang : Balas Dendam Sith Aubrey",
                "Ripiu Pelem bola : pada gerakan bumi by Aubrey",
                "Ripiu Pelem Takdir : pedang bekerja selamanya by Aubrey",
                "Ripiu Trailer GTA VI by Aubrey ",
                "Ripiu Trailer 2 GTA VI  by Aubrey",
                "Ripiu Pelem Attack on Titan: Final Season oleh Aubrey",
                "Ripiu Pelem Kungfu Panda 4 oleh Aubrey",
                "Ripiu Pelem Dune Part Two oleh Aubrey",
                "Ripiu Pelem Everything Everywhere All At Once oleh Aubrey",
                "Ripiu Pelem Suzume no Tojimari oleh Aubrey"
            };

            foreach (string title in filmTitles)
            {
                try
                {
                    // PRECONDITION: title tidak null dan <= 200
                    SayaTubeVideo video = new SayaTubeVideo(title);

                    // PRECONDITION: playcount tidak negatif dan <= 25.000.000
                    int randomPlayCount = new Random().Next(1, 1000000);
                    video.IncreasePlayCount(randomPlayCount);

                    // PRECONDITION: video tidak null dan belum mencapai int.MaxValue
                    user.AddVideo(video);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[EXCEPTION saat membuat/menambahkan video]: {ex.Message}");
                }
            }

            Console.WriteLine("\n=== Detail Maksimal 8 Video ===");
            user.PrintAllVideoPlaycount();

            Console.WriteLine($"\nTotal Play Count dari semua video: {user.GetTotalVideoPlayCount()}");

            // TEST EXCEPTION OVERFLOW
            Console.WriteLine("\n=== Uji Overflow ===");
            SayaTubeVideo overflowTest = new SayaTubeVideo("Video Overflow Test oleh Aubrey");
            overflowTest.IncreasePlayCount(int.MaxValue - 10);  // hampir penuh
            overflowTest.IncreasePlayCount(100); // seharusnya trigger exception
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[EXCEPTION dari Main]: {ex.Message}");
        }
    }
}
