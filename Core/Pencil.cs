namespace Core
{
    public class Pencil
    {
        private readonly Paper _paper;

        public Pencil(Paper paper)
        {
            _paper = paper;
        }

        public void Write(string text)
        {
            _paper.Insert(text);
        }
    }
}