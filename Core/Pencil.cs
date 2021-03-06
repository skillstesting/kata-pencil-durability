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
            _durability -= text.Length;
            _paper.Insert(text);
        }

        public bool? IsDull()
        {
            return _durability == 0;
        }
    }
}