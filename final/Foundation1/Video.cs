using System;

class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length) : this(title, author, length, [])
    {
    }

    public Video(string title, string author, int length, List<Comment> comments)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = comments;
    }

    public int GetCommentsCount()
    {
        return _comments.Count;
    }

    public string GetStringRepresentation()
    {   
        string stringRepresentation = $"Title: {_title}\nAuthor: {_author}\nLength in seconds: {_length}\nNumber of comments: {GetCommentsCount()}\n";
        if (_comments.Count > 0)
        {
            stringRepresentation += "Comments:";
            foreach(Comment comment in _comments)
            {
                stringRepresentation += $"\n\t{comment.GetAuthor()}: {comment.GetText()}";
            }
        }
        return stringRepresentation;
    }
}