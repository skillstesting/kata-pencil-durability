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
            if (_durability > 0)
                _paper.Remove(text);
        }
    }
}