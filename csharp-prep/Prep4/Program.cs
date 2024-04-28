using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        List<int> numbers = new List<int>();
        int userInput;
        Console.Write("Enter a list of numbers, type 0 when finished.\n");
        while (true)
        {
            Console.Write("Enter number: ");
            userInput = int.Parse(Console.ReadLine());
            if (userInput == 0)
            {
                break;
            }
            numbers.Add(userInput);
        }
        int sum = 0;
        int largest = -1;
        foreach (int number in numbers)
        {
            sum += number;
            if (number > largest)
            {
                largest = number;
            }
        }
        double average = (double) sum / numbers.Count;

        Console.WriteLine($"\nThe sum is {sum}.");
        Console.WriteLine($"\nThe average is {average}.");
        Console.WriteLine($"\nThe largest number is {largest}.");
    }
}