using System;

public class ScriptureRandomizer
{
    private List<Scripture> _scriptures = [];

    public ScriptureRandomizer(List<Scripture> scriptures)
    {
        _scriptures = scriptures;
    }

    public Scripture GetRandom()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(0, this._scriptures.Count);
        return this._scriptures[index];
    }
}