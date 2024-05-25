using System;

/*
* I've added the functionality to support Negative Goals.
* NegativeGoal is a derived class from EternalGoal. It only overrides the RecordEvent method to subtract the points instead of adding them.
*
* Also, the GetStringRepresentation method on the Goal class isn't abstract because the first part of the representation is the same for all 4 derived classes.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}