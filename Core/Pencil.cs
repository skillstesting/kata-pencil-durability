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
            foreach (var letter in text)
            {
                _durability -= char.IsUpper(letter) ? 2 : 1;
            }
            _paper.Insert(text);
        }

        public bool? IsDull()
        {
            return _durability == 0;
        }
    }
}