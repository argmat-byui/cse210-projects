using System;

class Swimming: Activity
{
    private int _numberOfLaps;


    public Swimming(DateOnly date, int duration, int numberOfLaps): base(date, duration)
    {
        _numberOfLaps = numberOfLaps;
    }

    public override double GetDistance()
    {
        return _numberOfLaps * 50 / 1000;
    }
}