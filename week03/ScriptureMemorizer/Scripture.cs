using System;
using System.Collections.Generic;
using System.Text;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<int> visibleIndices = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleIndices.Add(i);
            }
        }

        if (visibleIndices.Count == 0)
        {
            return;
        }

        int hideCount = Math.Min(numberToHide, visibleIndices.Count);
        Random random = new Random();

        for (int i = 0; i < hideCount; i++)
        {
            int pick = random.Next(visibleIndices.Count);
            int wordIndex = visibleIndices[pick];
            _words[wordIndex].Hide();
            visibleIndices.RemoveAt(pick);
        }
    }

    public string GetDisplayText()
    {
        StringBuilder display = new StringBuilder();
        display.AppendLine(_reference.GetDisplayText());
        display.AppendLine();

        for (int i = 0; i < _words.Count; i++)
        {
            if (i > 0)
            {
                display.Append(' ');
            }

            display.Append(_words[i].GetDisplayText());
        }

        return display.ToString();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}
