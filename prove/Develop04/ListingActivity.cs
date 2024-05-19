using System;

public class ListingActivity : Activity
{    
    private List<string> _prompts = new List<string>();
    private List<string> _allPrompts = new List<string>();

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        Init();
    }

    private void Init()
    {
        _allPrompts.Add("Who are people that you appreciate?");
        _allPrompts.Add("What are personal strengths of yours?");
        _allPrompts.Add("Who are people that you have helped this week?");
        _allPrompts.Add("When have you felt the Holy Ghost this month?");
        _allPrompts.Add("Who are some of your personal heroes?");
    }

    private void ResetPrompts()
    {
        _prompts.Clear();
        _prompts.AddRange(_allPrompts);
    }

    private string GetAndRemoveRandom(List<string> list)
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(0, list.Count);
        string result = list[index];
        list.RemoveAt(index);
        return result;
    }

    private string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
        {
            ResetPrompts();
        }
        return GetAndRemoveRandom(_prompts);
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"\n-- {GetRandomPrompt()} --\n");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        DateTime now = DateTime.Now;
        DateTime endTime = now.AddSeconds(_duration);
        // For this use there's no need to use an instance variable, so I'm just using a local one.
        int count = 0;
        while(DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You listed {count} item{(count == 1 ? "" : "s")}");
        DisplayEndingMessage();
    }
}