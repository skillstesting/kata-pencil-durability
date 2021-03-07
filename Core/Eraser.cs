using System.Linq;

namespace Core
{
    public class Eraser
    {
        private readonly Paper _paper;
        private int _durability;

        public Eraser(Paper paper, int durability = 1)
        {
            _paper = paper;
            _durability = durability;
        }

        public void Erase(string text)
        {
            if (IsDull()) return;

            if (_durability < text.Length)
            {
                text = text.Substring(text.Length - _durability, _durability);
            }
            _paper.Remove(text);

            foreach (var letter in text)
            {
                if (letter == ' ') continue;
                _durability--;
            }
        }

        public bool IsDull()
        {
            return _durability == 0;
        }
    }
}