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
        private readonly Eraser _eraser;
        private int? _startingPosition;

        public Pencil(Paper paper, int durability, int length = 1, int eraserDurability = 1)
        {
            _paper = paper;
            _eraser = new Eraser(paper, eraserDurability);
            _initialDurability = durability;
            _length = length;
            _durability = durability;
        }

        public void Write(string text, int? startingPosition = null)
        {
            _startingPosition = startingPosition;
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
                IncreaseStartingPosition();
            }
        }

        private void IncreaseStartingPosition()
        {
            if (_startingPosition == null) return;
            _startingPosition++;
        }

        private void WriteLetter(char letter)
        {
            InsertLetterOnPaper(letter);
            UpdateDurability(letter);
        }

        private void InsertLetterOnPaper(char letter)
        {
            _paper.Insert(IsDull() ? " " : letter.ToString(), _startingPosition);
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

        public void Erase(string text)
        {
            _eraser.Erase(text);
        }
    }
}