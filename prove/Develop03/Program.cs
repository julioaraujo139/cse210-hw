using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create a scripture instance
        Scripture scripture = new Scripture("Proverbs 3:5-6", "Trust in the Lord with all thine heart; and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths.");

        // Display the complete scripture
        Console.WriteLine(scripture.Display());

        // Prompt the user to press enter or type quit
        Console.WriteLine("Press Enter to hide some words or type 'quit' to exit.");
        string input = Console.ReadLine();

        int wordsToReplace = 3; // Número de palavras a serem substituídas por vez

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

            // Clear the console screen and display the updated scripture
            Console.Clear();
            Console.WriteLine(scripture.Display());

            // Check if all words are hidden, if true, exit the loop
            if (scripture.AllWordsHidden())
            {
                break;
            }

            // Prompt the user to press enter or type quit
            Console.WriteLine($"Press Enter to hide/replace more {wordsToReplace} words or type 'quit' to exit.");
            input = Console.ReadLine();
        }

        // Display a message when the program ends
        Console.WriteLine("All words replaced or hidden. Program ended.");
    }
}

class Scripture
{
    private ScriptureReference reference;
    public List<Word> words;

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
        // Randomly hide a few words
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
        // Encontre uma palavra não oculta para substituir
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
        // Verifique se todas as palavras estão ocultas
        return words.All(word => word.IsHidden);
    }
}

class ScriptureReference
{
    private string referenceText;

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
        
    }

    public bool IsHidden
    {
        get { return hidden; }
    }
}
