using System;

/*
* I've added the functionality to load scriptures from a file, and the program randomly chooses one of the words.
* I've used two separate classes to do this: ScriptureLoader to load the file, and ScriptureRandomizer to select a random one.
* Each line on the file represents a scripture with the form:{book} {chapter}:{startVerse}[:{endVerse}]|{scriptureText}. For example:
* 1 Nefi 3:7|And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.
*/

class Program
{
    static void Main(string[] args)
    {
        ScriptureLoader loader = new ScriptureLoader();
        List<Scripture> scriptures = loader.LoadFromFile("scriptures.txt");
        ScriptureRandomizer randomizer = new ScriptureRandomizer(scriptures);
        Scripture scripture = randomizer.GetRandom();
        do
        {
            Print(scripture);
            String userInput = Console.ReadLine();
            if (userInput.Trim() == "quit")
            {
                break;
            }
            scripture.HideRandomWords();
        } while(!scripture.IsCompletelyHidden());
        Print(scripture);
    }

    private static void Print(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\n\nPress enter to continue or type 'quit' to finish:");
    }
}