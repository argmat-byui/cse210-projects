using System;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();
    private List<string> _allPrompts = new List<string>();
    private List<string> _allQuestions = new List<string>();

    public ReflectingActivity()
    {
        _name = "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        Init();
    }

    private void Init()
    {
        InitPrompts();
        InitQuestions();
    }

    private void InitPrompts()
    {
        _allPrompts.Add("Think of a time when you stood up for someone else.");
        _allPrompts.Add("Think of a time when you did something really difficult.");
        _allPrompts.Add("Think of a time when you helped someone in need.");
        _allPrompts.Add("Think of a time when you did something truly selfless.");

    }

    private void ResetPrompts()
    {
        _prompts.Clear();
        _prompts.AddRange(_allPrompts);
    }

    private void ResetQuestions()
    {
        _questions.Clear();
        _questions.AddRange(_allQuestions);
    }

    private void InitQuestions()
    {
        _allQuestions.Add("Why was this experience meaningful to you?");
        _allQuestions.Add("Have you ever done anything like this before?");
        _allQuestions.Add("How did you get started?");
        _allQuestions.Add("How did you feel when it was complete?");
        _allQuestions.Add("What made this time different than other times when you were not as successful?");
        _allQuestions.Add("What is your favorite thing about this experience?");
        _allQuestions.Add("What could you learn from this experience that applies to other situations?");
        _allQuestions.Add("What did you learn about yourself through this experience?");
        _allQuestions.Add("How can you keep this experience in mind in the future?");
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

    private string GetRandomQuestion()
    {
        if (_questions.Count == 0)
        {
            ResetQuestions();
        }
        return GetAndRemoveRandom(_questions);
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"\n-- {GetRandomPrompt()} --\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();
        DateTime now = DateTime.Now;
        DateTime endTime = now.AddSeconds(_duration);
        while(DateTime.Now < endTime)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(5);
        }
        Console.WriteLine();
        DisplayEndingMessage();
    }
}