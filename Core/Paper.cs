using System;

namespace Core
{
    public class Paper
    {
        private string _text = string.Empty;
        public void Insert(string text)
        {
            _text += text;
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

        public void Edit(int startingPosition, string text)
        {
            var startingIndex = startingPosition - 1;
            foreach (var letter in text)
            {
                AddLetterToText(startingIndex, letter);
                startingIndex++;
            }
        }

        private void AddLetterToText(int startingIndex, char letter)
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