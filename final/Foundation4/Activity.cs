using System;

abstract class Activity
{
    private DateOnly _date;
    private int _duration;


    public Activity(DateOnly date, int duration)
    {
        _date = date;
        _duration = duration;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public virtual string GetActivityName()
    {
        return GetType().Name;
    }

    public abstract double GetDistance();

    public virtual double GetSpeed()
    {
        return GetDistance() / GetDuration() * 60;
    }

    public double GetPace()
    {
        return GetDuration() / GetDistance();
    }

    public string GetSummary()
    {
        return $"{_date} {GetActivityName()} ({_duration} min) - Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}