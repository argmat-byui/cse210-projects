using System;

public class GoalManager
{
    private static string CREATE_NEW_GOAL_OPTION = "Create New Goal";
    private static string LIST_GOALS_OPTION = "List Goals";
    private static string SAVE_GOALS_OPTION = "Save Goals";
    private static string LOAD_GOALS_OPTION = "Load Goals";
    private static readonly string RECORD_EVENT_OPTION = "Record Event";
    private static readonly string QUIT_OPTION = "Quit";
    private static readonly string INVALID_OPTION = "Invalid Option";
    private static readonly int SIMPLE_GOAL = 1;
    private static readonly int ETERNAL_GOAL = 2;
    private static readonly int CHECKLIST_GOAL = 3;
    private static readonly int NEGATIVE_GOAL = 4;
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public void Start()
    {
        Console.Clear();
        String[] options =
        [
            CREATE_NEW_GOAL_OPTION, 
            LIST_GOALS_OPTION,
            SAVE_GOALS_OPTION,
            LOAD_GOALS_OPTION,
            RECORD_EVENT_OPTION,
            QUIT_OPTION
        ];
        string selectedOption;
        do
        {
            DisplayPlayerInfo();
            ShowMenu(options);
            int selectedIndex = ReadInputFromUser() - 1;
            selectedOption = selectedIndex >= 0 && selectedIndex < options.Length ? options[selectedIndex] : INVALID_OPTION;
            if (selectedOption != QUIT_OPTION)
            {
                if (selectedOption == CREATE_NEW_GOAL_OPTION)
                {
                    CreateGoal();
                }
                else if (selectedOption == LIST_GOALS_OPTION)
                {
                    ListGoalDetails();
                }
                else if (selectedOption == SAVE_GOALS_OPTION)
                {
                    SaveGoals();
                }
                else if (selectedOption == LOAD_GOALS_OPTION)
                {
                    LoadGoals();
                }
                else if (selectedOption == RECORD_EVENT_OPTION)
                {
                    RecordEvent();
                }
                else
                {
                    Console.WriteLine($"Invalid choice. Valid options are 1 to {options.Length}. Try again.\n");
                }
            }
        } while (selectedOption != QUIT_OPTION);
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.\n");
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal");
        Console.Write("Which type of goal would you like to create? ");
        int goalType = int.Parse(Console.ReadLine());
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());
        Goal goal = null;
        if (goalType == SIMPLE_GOAL)
        {
            goal = new SimpleGoal(name, description, points);
        }
        else if (goalType == ETERNAL_GOAL)
        {
            goal = new EternalGoal(name, description, points);
        }
        else if (goalType == NEGATIVE_GOAL)
        {
            goal = new NegativeGoal(name, description, points);
        }
        else if (goalType == CHECKLIST_GOAL)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            goal = new ChecklistGoal(name, description, points, target, bonus);
        }
        AddGoal(goal);
    }

    private void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        int index = 1;
        foreach(Goal goal in _goals)
        {
            Console.WriteLine($"{index++}. {goal.GetDetailsString()}");
        }
    }

    private void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        int index = 1;
        foreach(Goal goal in _goals)
        {
            Console.WriteLine($"{index++}. {goal.GetShortName()}");
        }
    }

    private void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;
        Goal goal = _goals[index];
        int points = goal.RecordEvent();
        _score += points;
        if (points > 0)
        {
            Console.WriteLine($"Congratulations! You have earned {points} points!");
        }
        else if (points < 0)
        {
            Console.WriteLine($"You have lost {-points} points. Don't give up!");
        }
        Console.WriteLine($"You have now {_score} points.");
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
            
        }
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        String[] lines = System.IO.File.ReadAllLines(filename);
        _score = int.Parse(lines.First());
        _goals = new List<Goal>();
        foreach(String line in lines.Skip(1).ToArray())
        {
            String[] lineParts = line.Split(":");
            string className = lineParts[0];
            string[] goalParts = lineParts[1].Split(Goal.GetStringRepresentationSeparator());
            string name = goalParts[0];
            string description = goalParts[1];
            int points = int.Parse(goalParts[2]);
            Goal goal = null;
            if (className == "SimpleGoal")
            {
                goal = new SimpleGoal(name, description, points, bool.Parse(goalParts[3]));
            }
            else if (className == "EternalGoal")
            {
                goal = new EternalGoal(name, description, points);
            }
            else if (className == "NegativeGoal")
            {
                goal = new NegativeGoal(name, description, points);
            }
            else if (className == "ChecklistGoal")
            {
                int bonus = int.Parse(goalParts[3]);
                int target = int.Parse(goalParts[4]);
                int amountCompleted = int.Parse(goalParts[5]);
                goal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
            }
            if (goal != null)
            {
                AddGoal(goal);
            }
        }
    }

    private void ShowMenu(String[] options)
    {
        Console.WriteLine("Menu Options:");
        int index = 1;
        foreach (String option in options)
        {
            Console.WriteLine($"  {index++}. {option} ");
        }

        Console.Write("Select a choice from the menu: ");
    }

    private int ReadInputFromUser()
    {
        try
        {
            string userInput = Console.ReadLine();
            return int.Parse(userInput);
        }
        catch (Exception)
        {
            return -1;
        }
        
    }
}