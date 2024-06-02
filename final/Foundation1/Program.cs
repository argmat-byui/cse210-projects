using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Introductory Pages of the Book of Mormon, Come Follow Me", "Teaching with Power", 4856,
        [
            new Comment("maryjeanfrancisquete9079", "I am a Sunday School teacher and you have helped me a lot. Thank you."),
            new Comment("kentnuttall2947", "I have listened to you off and on throughout the years, and your lessons are absolutely wonderful. And today is no different The spirit was teaching me through you thank you."),
            new Comment("aliciamilne2302", "Thank you, wanting to turn around and then be able to teach this to others, ESPECIALLY to my kids is so important and needed !")
        ]);

        Video video2 = new Video("100 Most Iconic Video Game Songs (1980-2018)", "Ensnare", 1644,
        [
            new Comment("ProfKim", "100 Most Iconic Copyright Claims..."),
            new Comment("GhostbustersHQ", "6:51 what a beautiful melody"),
            new Comment("VoltaNid", "12:55 Hits me hard with nostalgia of playing this game")
        ]);

        Video video3 = new Video("Obi-Wan Kenobi vs Darth Vader Full Fight Scene Part 6 Finale Episode 6 Season 1 2K HD", "Nukem Clips", 567,
        [
            new Comment("NevanSlone", "Luke- “You told me Vader murdered my father”\nBen- “It’s literally what he said”"),
            new Comment("joshwb4lif329", "The way they “mixed” anakins voice with the module….is absolute perfection….literal BEST scene in ANY of the movies, hands down"),
            new Comment("mcbone2178", "Kenobi took off part of the helmet from the left side, while Ahsoka took it from the right. And at the end, Luke took off the whole mask.")
        ]);

        List<Video> videos = [video1, video2, video3];
        foreach(Video video in videos)
        {
            Console.WriteLine(video.GetStringRepresentation() + "\n\n");
        }
    }
}