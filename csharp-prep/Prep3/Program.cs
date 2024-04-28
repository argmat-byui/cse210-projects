using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        int userInput;
        do
        {
            Console.Write("\nWhat is your guess? ");
            userInput = int.Parse(Console.ReadLine());
            if (magicNumber > userInput)
            {
                Console.Write("Higher");
            }
            else if (magicNumber < userInput)
            {
                Console.Write("Lower");
            }
            else
            {
                Console.Write("You guessed it\n");
                break;
            }
        } while (userInput != magicNumber);
    }
}