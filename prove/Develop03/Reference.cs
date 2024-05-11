using System;

public class Reference
{   
    private String _book;
    private int _chapter;
    private int _startVerse;
    private int? _endVerse;

    public Reference(String book, int chapter, int startVerse): this(book, chapter, startVerse, null) {}

    public Reference(String book, int chapter, int startVerse, int? endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public String GetDisplayText()
    {
        String displayText = $"{_book} {_chapter}:{_startVerse}";
        if (_endVerse != null)
        {
            displayText += $"-{_endVerse}";
        }
        return displayText;
    }
}