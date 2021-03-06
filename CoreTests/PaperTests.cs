using Core;
using NUnit.Framework;

namespace CoreTests
{
    public class PaperTests
    {
        private const string Foo = "foo";
        private const string Bar = "bar";
        private const string FooBar = Foo + Bar;
        private const string Space = " ";
        private Paper _paper;
        
        [SetUp]
        public void SetUp()
        {
            _paper = new Paper();
        }
        
        [Test]
        public void PaperDisplaysText_WhenTextIsInserted()
        {
            _paper.Insert(Foo);
            
            Assert.AreEqual(Foo, _paper.Read());
        }

        [Test]
        public void PaperDisplaysEmptyText_ByDefault()
        {
            Assert.AreEqual(string.Empty, _paper.Read());
        }

        [Test]
        public void PaperDisplaysAllText_WhenTextIsInsertedTwice()
        {
            _paper.Insert(Foo);
            _paper.Insert(Bar);
            
            Assert.AreEqual(FooBar, _paper.Read());
        }

        [Test]
        public void PaperDisplaysTextWithOneSpace_WhenTextWithOneLetterIsRemoved()
        {
            _paper.Insert("F");
            _paper.Remove("F");
            
            Assert.AreEqual(Space, _paper.Read());
        }

        [Test]
        public void PaperDisplaysTextWithTwoSpaces_WhenTextWithTwoLettersIsRemoved()
        {
            _paper.Insert("Fo");
            _paper.Remove("Fo");
            
            Assert.AreEqual(Space + Space, _paper.Read());
        }

        [Test]
        public void PaperDisplaysRemainingTextWithSpaces_WhenSomeTextIsRemoved()
        {
            _paper.Insert(FooBar);
            _paper.Remove(Bar);
            
            Assert.AreEqual(Foo + Space + Space + Space, _paper.Read());
        }
    }
}