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
            var spaces = string.Empty;
            for (var i = 0; i < text.Length; i++) spaces = spaces.Insert(i, " ");
            _text = spaces;
        }
    }
}