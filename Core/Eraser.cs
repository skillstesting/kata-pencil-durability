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
            if (!IsDull())
            {
                _paper.Remove(text);
                _durability--;
            }
        }

        public bool IsDull()
        {
            return _durability == 0;
        }
    }
}