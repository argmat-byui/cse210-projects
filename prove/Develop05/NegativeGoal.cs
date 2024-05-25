using System;

public class NegativeGoal : EternalGoal
{
    public NegativeGoal(string shortName, string description, int points): base(shortName, description, points)
    {
    }

    public override int RecordEvent()
    {
        return -base.RecordEvent();
    }
}