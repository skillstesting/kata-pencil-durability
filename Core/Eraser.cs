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
            EraseText(text);
            UpdateDurability(text);
        }

        private void EraseText(string text)
        {
            _paper.Remove(GetTextThatCanBeErased(text));
        }

        private void UpdateDurability(string text)
        {
            _durability -= TextCountWithoutSpaces(GetTextThatCanBeErased(text));
        }

        private static int TextCountWithoutSpaces(string textToErase)
        {
            return textToErase.Count(c => !char.IsWhiteSpace(c));
        }

        private string GetTextThatCanBeErased(string textToErase)
        {
            return AllTextCanBeErased(TextCountWithoutSpaces(textToErase)) ? textToErase : TextThatCanBeErased(textToErase);
        }

        private bool AllTextCanBeErased(int textCountWithoutSpaces)
        {
            return _durability >= textCountWithoutSpaces;
        }

        private string TextThatCanBeErased(string textToErase)
        {
            return textToErase.Substring(textToErase.Length - _durability, _durability);
        }

        public bool IsDull()
        {
            return _durability == 0;
        }
    }
}