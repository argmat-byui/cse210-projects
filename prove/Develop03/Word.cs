using System;

public class Word
{   
    private String _text;
    private Boolean _hidden = false;

    public Word(String text)
    {
        _text = text;
    }

    public void Hide()
    {
        _hidden = true;
    }

    public void Show()
    {
        _hidden = false;
    }

    public Boolean IsHidden()
    {
        return _hidden;
    }

    public String GetDisplayText()
    {
        return _hidden ? new String('_', _text.Length) : _text;
    }

}