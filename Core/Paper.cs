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
                _text = _text.Remove(lastTextPosition, text.Length)
                    .Insert(lastTextPosition, GetTextSpaces(text));
            }
        }

        private static string GetTextSpaces(string text)
        {
            var spaces = string.Empty;
            for (var i = 0; i < text.Length; i++) spaces = spaces.Insert(i, " ");
            return spaces;
        }
    }
}