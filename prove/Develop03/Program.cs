using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture("Proverbs 3:5-6", "Trust in the Lord with all thine heart; and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths.");

        Console.WriteLine(scripture.Display());

        Console.WriteLine("Press Enter to hide some words or type 'quit' to exit.");
        string input = Console.ReadLine();

        int wordsToReplace = 3;

        while (input.ToLower() != "quit")
        {
            if (input == "")
            {
                for (int i = 0; i < wordsToReplace; i++)
                {
                    scripture.ReplaceWordWithCharacters();
                }
            }
            else
            {
                scripture.HideRandomWords();
            }

            Console.Clear();
            Console.WriteLine(scripture.Display());

            if (scripture.AllWordsHidden())
            {
                break;
            }

            Console.WriteLine($"Press Enter to hide/replace more {wordsToReplace} words or type 'quit' to exit.");
            input = Console.ReadLine();
        }
    }
}

class Scripture
{
    private readonly ScriptureReference reference;
    private readonly List<Word> words;

    public Scripture(string referenceText, string scriptureText)
    {
        reference = new ScriptureReference(referenceText);
        words = scriptureText.Split(' ').Select(word => new Word(word)).ToList();
    }

    public string Display()
    {
        return $"{reference.Display()} {string.Join(" ", words.Select(word => word.Display()))}";
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, words.Count / 2);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(words.Count);
            words[index].Hide();
        }
    }

    public void ReplaceWordWithCharacters()
    {
        var visibleWords = words.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Count > 0)
        {
            Random random = new Random();
            int index = random.Next(visibleWords.Count);
            visibleWords[index].ReplaceWithCharacters();
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }
}

class ScriptureReference
{
    private readonly string referenceText;

    public ScriptureReference(string referenceText)
    {
        this.referenceText = referenceText;
    }

    public string Display()
    {
        return $"{referenceText}";
    }
}

class Word
{
    private string text;
    private bool hidden;

    public Word(string text)
    {
        this.text = text;
        hidden = false;
    }

    public string Display()
    {
        return hidden ? "_" : text;
    }

    public void Hide()
    {
        hidden = true;
    }

    public void ReplaceWithCharacters()
    {
        char replacementChar = '_';
        text = new string(replacementChar, text.Length);
        hidden = true;
    }

    public bool IsHidden => hidden;
}
