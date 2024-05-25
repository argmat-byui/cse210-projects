using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus): this(shortName, description, points, target, bonus, 0)
    {
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus, int amountCompleted): base(shortName, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        int points = GetPoints();
        if (_amountCompleted == _target)
        {
            points += _bonus;
        }
        return points;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        string separator = GetStringRepresentationSeparator();
        return $"{base.GetStringRepresentation()}{separator}{_bonus}{separator}{_target}{separator}{_amountCompleted}";
    }
}