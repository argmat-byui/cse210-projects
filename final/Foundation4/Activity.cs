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

    // GetSpeed needs to be overriden by the Cycling Activity, but other activities can just use this implementation.
    public virtual double GetSpeed()
    {
        return GetDistance() / GetDuration() * 60;
    }


    // GetPace doesn't need to have a different implementation in each derived class, that's why I'm not making this virtual.
    public double GetPace()
    {
        return GetDuration() / GetDistance();
    }

    public string GetSummary()
    {
        return $"{_date} {GetActivityName()} ({_duration} min) - Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}