using System;
using System.Collections.Generic;

namespace Core
{
    public class Pencil
    {
        private readonly Paper _paper;
        private readonly int _initialDurability;
        private int _length;
        private int _durability;

        public Pencil(Paper paper, int durability, int length = 1)
        {
            _paper = paper;
            _initialDurability = durability;
            _length = length;
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
            if (letter == ' ' || IsDull()) return;
            _durability -= char.IsUpper(letter) ? 2 : 1;
        }

        public bool IsDull()
        {
            return _durability == 0;
        }

        public void Sharpen()
        {
            if (_length == 0) return;
            _durability = _initialDurability;
            _length--;
        }

        public void Edit(int startingPosition, string text)
        {
            _paper.Edit(startingPosition, text);
        }
    }
}