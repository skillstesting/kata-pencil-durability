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
    }
}