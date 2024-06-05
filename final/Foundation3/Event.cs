using System;

abstract class Event
{
    private string _title;
    private string _description;
    private DateOnly _date;
    private TimeOnly _time;
    private Address _address;


    public Event(string title, string description, DateOnly date, TimeOnly time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public virtual string GetTypeOfEvent()
    {
        return GetType().Name;
    }

    public string GetStandardDetailsMessage()
    {
        return $"{_title}\n\n{_description}\n{_date} {_time}\n\n{_address.GetStringRepresentation()}";   
    }

    public virtual string GetFullDetailsMessage()
    {
        return $"{GetStandardDetailsMessage()}\n{GetTypeOfEvent()}";
    }

    public string GetShortDescription()
    {
        return $"{GetTypeOfEvent()} - {_title} - {_date}";
    }
}