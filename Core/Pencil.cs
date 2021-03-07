using System;
using System.Collections.Generic;

namespace Core
{
    public class Pencil
    {
        private readonly Paper _paper;
        private int _durability;

        public Pencil(Paper paper, int durability)
        {
            _paper = paper;
            _durability = durability;
        }

        public void Write(string text)
        {
            var textLines = text.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
            if (textLines.Length > 1)
            {
                WriteTextFromAllLines(textLines);
            }
            else
            {
                WriteAllTextLetters(text);
            }
        }

        private void WriteTextFromAllLines(IReadOnlyList<string> textLines)
        {
            for (var index = 1; index < textLines.Count; index++)
            {
                WriteTextToLine(textLines[index]);
            }
        }

        private void WriteTextToLine(string text)
        {
            _paper.Insert(Environment.NewLine);
            WriteAllTextLetters(text);
        }

        private void WriteAllTextLetters(string text)
        {
            foreach (var letter in text)
            {
                WriteLetter(letter);
            }
        }

        private void WriteLetter(char letter)
        {
            InsertLetterOnPaper(letter);
            UpdateDurability(letter);
        }

        private void InsertLetterOnPaper(char letter)
        {
            _paper.Insert(IsDull() ? " " : letter.ToString());
        }

        private void UpdateDurability(char letter)
        {
            if (letter == ' ') return;
            _durability -= char.IsUpper(letter) ? 2 : 1;
        }

        public bool IsDull()
        {
            return _durability == 0;
        }
    }
}