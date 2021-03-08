using System;

namespace Core
{
    public class Paper
    {
        private string _text = string.Empty;

        public void Insert(string text, int? startingPosition = null)
        {
            var startingIndex = startingPosition - 1 ?? _text.Length + 1;
            foreach (var letter in text)
            {
                AddLetterToText(letter, startingIndex);
                startingIndex++;
            }
        }

        public string Read()
        {
            return _text;
        }

        public void Remove(string text)
        {
            var lastTextPosition = _text.LastIndexOf(text, StringComparison.Ordinal);
            if (lastTextPosition >= 0)
            {
                _text = ReplaceTextWithSpaces(lastTextPosition, text.Length);
            }
        }

        private string ReplaceTextWithSpaces(int startingPosition, int length)
        {
            return _text.Remove(startingPosition, length)
                .Insert(startingPosition, GenerateSpaces(length));
        }

        private static string GenerateSpaces(int length)
        {
            var spaces = string.Empty;
            for (var i = 0; i < length; i++) spaces = spaces.Insert(i, " ");
            return spaces;
        }

        private void AddLetterToText(char letter, int startingIndex)
        {
            if (startingIndex < _text.Length)
            {
                _text = _text.Remove(startingIndex, 1)
                    .Insert(startingIndex, _text[startingIndex] == ' ' ? letter.ToString() : "@");
            }
            else
            {
                _text += letter;
            }
        }
    }
}