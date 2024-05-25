using System;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public string GetShortName()
    {
        return _shortName;
    }

    public int GetPoints()
    {
        return _points;
    }

    public static string GetStringRepresentationSeparator()
    {
        return "|";
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_description})";
    }

    public virtual string GetStringRepresentation()
    {
        string separator = GetStringRepresentationSeparator();
        return $"{GetType().Name}:{_shortName}{separator}{_description}{separator}{_points}";
    }
}