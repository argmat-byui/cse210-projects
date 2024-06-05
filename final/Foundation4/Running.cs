using System;

class Running: Activity
{
    private double _distance;


    public Running(DateOnly date, int duration, double distance): base(date, duration)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }
}