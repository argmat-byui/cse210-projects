using System;

class Cycling: Activity
{
    private double _speed;


    public Cycling(DateOnly date, int duration, double speed): base(date, duration)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return _speed * GetDuration() / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }
}