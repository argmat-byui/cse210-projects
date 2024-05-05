using System;
using System.IO.Compression;

// I've added the option to delete an entry

class Program
{
    private static int QUIT_OPTION = 6;
    private static PromptGenerator promptGenerator = new PromptGenerator();
    private static Journal journal = new Journal();
    static void Main(string[] args)
    {
        String[] options = ["Write", "Display", "Delete Entry", "Load", "Save", "Quit"];
        Console.WriteLine("Welcome to the Journal Program!");
        int selected;
        do
        {
            ShowMenu(options);
            selected = ReadInputFromUser();
            if (selected == 1)
            {
                WriteEntry();
            }
            else if (selected == 2)
            {
                Display();
            }
            else if (selected == 3)
            {
                Console.WriteLine("What entry do you want to delete?");
                String userInput = Console.ReadLine();
                int index = int.Parse(userInput) - 1;
                journal.DeleteEntry(index);
            }
            else if (selected == 4)
            {
                Console.WriteLine("What is the filename?");
                String filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (selected == 5)
            {
                Console.WriteLine("What is the filename?");
                String filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
        } while (selected != QUIT_OPTION);
        Console.WriteLine("Out");
        
    }

    static void WriteEntry()
    {
        String prompt = promptGenerator.GetRandom();
        Console.WriteLine(prompt);
        Entry entry = new Entry();
        entry._promptText = prompt;
        entry._entryText = Console.ReadLine();
        entry._date = DateTime.Now.ToString("MM-dd-yyyy");
        journal.AddEntry(entry);
    }

    static void Display()
    {
        journal.DisplayAll();
        Console.WriteLine();
    }

    static void ShowMenu(String[] options)
    {
        int index = 0;
        foreach (String option in options)
        {
            index++;
            Console.WriteLine($"{index}. {option} ");
        }

        Console.WriteLine("What would you like to do? ");
    }

    static int ReadInputFromUser() {
        string userInput = Console.ReadLine();
        return int.Parse(userInput);
    }
}