using System;

/*
* I've added the functionality to prevent questions and prompts to be used twice before using every single one of them.
* This was done for both ReflectingActivity and ListingActivity
*/

class Program
{
    private static int QUIT_OPTION = 4;
    static void Main(string[] args)
    {
        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectingActivity reflectingActivity = new ReflectingActivity();
        ListingActivity listingActivity = new ListingActivity();

        String[] options = ["Start breathing activity", "Start reflecting activity", "Start listing activity", "Quit"];
        int selected;
        do
        {
            ShowMenu(options);
            selected = ReadInputFromUser();
            if (selected == 1)
            {
                breathingActivity.Run();
            }
            else if (selected == 2)
            {
                reflectingActivity.Run();
            }
            else if (selected == 3)
            {
                listingActivity.Run();
            }
        } while (selected != QUIT_OPTION);
    }

    static void ShowMenu(String[] options)
    {
        Console.Clear();
        Console.WriteLine("Menu Options:");
        int index = 0;
        foreach (String option in options)
        {
            index++;
            Console.WriteLine($"{index}. {option} ");
        }

        Console.Write("Select a choice from the menu: ");
    }

    static int ReadInputFromUser()
    {
        string userInput = Console.ReadLine();
        return int.Parse(userInput);
    }
}
