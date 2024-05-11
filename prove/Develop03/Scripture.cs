using System;

public class Scripture
{   
    private Reference _reference;
    private List<Word> _words = [];

    public Scripture(Reference reference, String text)
    {
        _reference = reference;
        foreach(String word in text.Split(" "))
        {
            _words.Add(new Word(word));
        }
    }

    public String GetDisplayText()
    {
        String displayText = $"{_reference.GetDisplayText()} ";
        foreach(Word word in _words)
        {
            displayText += $"{word.GetDisplayText()} ";
        }
        return displayText;
    }

    private List<Word> GetVisibleWords()
    {
        return _words.Where(word => !word.IsHidden()).ToList();
    }

    public Boolean IsCompletelyHidden()
    {
        return GetVisibleWords().Count == 0;
    }

    public void HideRandomWords()
    {
        List<Word> visibleWords = GetVisibleWords();
        Random randomGenerator = new Random();
        int toHide = (int)Math.Ceiling((double)_words.Count/10);
        int count = Math.Min(visibleWords.Count, toHide);
        for( int i = 0; i < count; i++)
        {
            int index = randomGenerator.Next(0, visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }
}