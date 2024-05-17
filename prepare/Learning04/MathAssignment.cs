using System;

public class MathAssignment: Assignment
{
    private String _textBookSection;
    private String _problems;

    public MathAssignment(String studentName, String topic, String textBookSection, String problems):base(studentName, topic)
    {
        _textBookSection = textBookSection;
        _problems = problems;
    }

    public String GetHomeworkList()
    {
        return $"Section {_textBookSection} Problems {_problems}";
    }
}