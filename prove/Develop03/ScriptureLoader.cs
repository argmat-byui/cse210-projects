using System;

public class ScriptureLoader
{   
    private static String DEFAULT_SEPARATOR = "|";
    private String _separator = DEFAULT_SEPARATOR;

    public ScriptureLoader(): this(DEFAULT_SEPARATOR) {}

    public ScriptureLoader(String separator)
    {
        _separator = separator;
    }

    public List<Scripture> LoadFromFile(String file)
    {
        List<Scripture> scriptures = new List<Scripture>();
        String[] lines = System.IO.File.ReadAllLines(file);
        foreach(String line in lines)
        {
            scriptures.Add(ParseLine(line));
        }
        return scriptures;
    }

    private Scripture ParseLine(String line)
    {
        String[] parts = line.Split(_separator);
        Reference reference = ParseReference(parts[0]);
        return new Scripture(reference, parts[1]);
    }

    private Reference ParseReference(String referenceString)
    {
        int bookEndingIndex = referenceString.LastIndexOf(' ');
        String book = referenceString.Substring(0, bookEndingIndex);
        String rest = referenceString.Substring(bookEndingIndex + 1);
        String[] restParts = rest.Split(":");
        int chapter = int.Parse(restParts[0]);
        String[] verses = restParts[1].Split("-");
        int startVerse = int.Parse(verses[0]);
        int? endVerse = verses.Length > 1 ? int.Parse(verses[1]) : null;
        return new Reference(book, chapter, startVerse, endVerse);
    }
}