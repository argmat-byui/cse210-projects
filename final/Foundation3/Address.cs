using System;

class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        List<string> usaValidSpellings = ["United States", "United States of America", "USA"];
        return usaValidSpellings.Select(s => s.ToLower()).ToList().Contains(_country.ToLower());
    }

    public string GetStringRepresentation()
    {
        return $"{_street}, {_city}, {_state}, {_country}";
    }
}