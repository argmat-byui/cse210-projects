using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points): this(shortName, description, points, false)
    {
    }

    public SimpleGoal(string shortName, string description, int points, bool isComplete): base(shortName, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        string separator = GetStringRepresentationSeparator();
        return $"{base.GetStringRepresentation()}{separator}{_isComplete}";
    }
}