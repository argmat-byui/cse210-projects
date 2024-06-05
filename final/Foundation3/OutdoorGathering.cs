using System;

class OutdoorGathering: Event
{
    private string _weatherForecast;

    public OutdoorGathering(string title, string description, DateOnly date, TimeOnly time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        _weatherForecast = weatherForecast;
    }

    public override string GetTypeOfEvent()
    {
        return "Outdoor gathering";
    }

    public override string GetFullDetailsMessage()
    {
        return $"{base.GetFullDetailsMessage()}\nWeather forecast: {_weatherForecast}";
    }
}