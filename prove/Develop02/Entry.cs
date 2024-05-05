using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public void Display() {
        Console.WriteLine($"Date: {this._date} - Prompt: {this._promptText}\n{this._entryText}");
    }

    
}