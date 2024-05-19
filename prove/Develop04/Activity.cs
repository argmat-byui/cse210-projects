using System;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
    }

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        int duration = int.Parse(Console.ReadLine());
        _duration = duration;
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Well done!!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed another {_duration} second{(_duration == 1 ? "" : "s")} of the {_name} Activity");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animationStrings = "|/-\\|/-\\".ToCharArray().Select(c => c.ToString()).ToList();
        DateTime now = DateTime.Now;
        DateTime endTime = now.AddSeconds(seconds);
        int i = 0;
        while(DateTime.Now < endTime)
        {
            Console.Write(animationStrings[i]);
            Thread.Sleep(500);
            Console.Write("\b \b");
            i = (i + 1) % animationStrings.Count;
        }
        Console.WriteLine("");
    }

    public void ShowCountDown(int seconds)
    {
        for(int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            string backSpaces = new string('\b', seconds.ToString().Length);
            string blankSpaces = new string(' ', seconds.ToString().Length);
            Console.Write($"{backSpaces}{blankSpaces}{backSpaces}");
        }
        Console.WriteLine("");
    }
}