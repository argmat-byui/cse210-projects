using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your grade in percentage: ");
        string userInput = Console.ReadLine();
        int percentage = int.Parse(userInput);
        string letter = "F";
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >=80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        Console.WriteLine($"\nYour letter grade is {letter}.");
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed.");
        }
        else
        {
            Console.WriteLine("Sorry, try again next time.");
        }
    }
}