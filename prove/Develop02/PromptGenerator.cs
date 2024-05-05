using System;

public class PromptGenerator
{
    public List<String> _prompts = [
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What's one thing you thought today to help others?"
    ];

    public String GetRandom() {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(0, this._prompts.Count);
        return this._prompts[index];
    }
    
}