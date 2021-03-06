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
        public void PaperDisplaysFirstInstanceOfTextWithSpaces_WhenTextIsRemoved()
        {
            _paper.Insert(FooBar);
            _paper.Insert(FooBar);
            _paper.Remove(Bar);
            
            Assert.AreEqual(FooBar + Foo + Space + Space + Space , _paper.Read());
        }

        [Test]
        public void PaperDisplaysOriginalText_WhenTextBeingRemovedDoesntExist()
        {
            _paper.Insert(Foo);
            _paper.Remove(Bar);
            
            Assert.AreEqual(Foo , _paper.Read());
        }

        [Test]
        public void PaperDisplaysAllTextWithPartialEdit_AndAtSymbol_WhenEditTextIsLongerThanAvailableSpace()
        {
            _paper.Insert(Foo + Space + Space + Foo);
            _paper.Edit(4, Bar);
            
            Assert.AreEqual(Foo + "ba@oo", _paper.Read());
        }

        [Test]
        public void PaperDisplaysAllTextWithPartialEdit_AndAtSymbol_WhenEditTextIsAddedAtEndOfText()
        {
            _paper.Insert(Foo + Space + Foo);
            _paper.Edit(4, FooBar);
            
            Assert.AreEqual(Foo + "f@@@ar", _paper.Read());
        }
    }
}