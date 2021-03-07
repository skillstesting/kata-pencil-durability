using System;

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
                for (var index = 1; index < textLines.Length; index++)
                {
                    _paper.Insert(Environment.NewLine);
                    foreach (var letter in textLines[index])
                    {
                        _paper.Insert(IsDull() ? " " : letter.ToString());
                    }
                }
            }
            else
            {
                foreach (var letter in text)
                {
                    _paper.Insert(IsDull() ? " " : letter.ToString());
                    if (letter == ' ') continue;
                    _durability -= char.IsUpper(letter) ? 2 : 1;
                }
            }
        }

        public bool IsDull()
        {
            return _durability == 0;
        }
    }
}