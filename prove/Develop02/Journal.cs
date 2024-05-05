using System;
using System.IO;

public class Journal
{   
    private static String SEPARATOR = "|";
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry) {
        this._entries.Add(entry);
    }

    public void DeleteEntry(int index) {
        this._entries.RemoveAt(index);
    }

    public void LoadFromFile(String file) {
        _entries = new List<Entry>();
        String[] lines = System.IO.File.ReadAllLines(file);
        foreach(String line in lines)
        {
            String[] parts = line.Split(SEPARATOR);
            Entry entry = new Entry();
            entry._date = parts[0];
            entry._promptText = parts[1];
            entry._entryText = parts[2];
            AddEntry(entry);
        }
    }

    public void SaveToFile(String file) {
        using  (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in this._entries)
            {
                outputFile.WriteLine($"{entry._date}{SEPARATOR}{entry._promptText}{SEPARATOR}{entry._entryText}");
            }
            
        }
    }

    public void DisplayAll() {
        int index = 1;
        foreach (Entry entry in this._entries)
        {
            Console.Write($"{index}: ");
            index++;
            entry.Display();
        }
    }

    
}