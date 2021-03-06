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
    }
}