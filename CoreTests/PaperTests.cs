using Core;
using NUnit.Framework;

namespace CoreTests
{
    public class PaperTests
    {
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
            _paper.Insert(TestSetup.Foo);
            _paper.Insert(TestSetup.Bar);
            
            Assert.AreEqual(TestSetup.FooBar, _paper.Read());
        }

        [Test]
        public void PaperDisplaysFirstInstanceOfTextWithSpaces_WhenTextIsRemoved()
        {
            _paper.Insert(TestSetup.FooBar);
            _paper.Insert(TestSetup.FooBar);
            _paper.Remove(TestSetup.Bar);

            const string expectedText = TestSetup.FooBar + TestSetup.Foo + 
                                        TestSetup.Space + TestSetup.Space + TestSetup.Space;
            Assert.AreEqual(expectedText, _paper.Read());
        }

        [Test]
        public void PaperDisplaysOriginalText_WhenTextBeingRemovedDoesntExist()
        {
            _paper.Insert(TestSetup.Foo);
            _paper.Remove(TestSetup.Bar);
            
            Assert.AreEqual(TestSetup.Foo , _paper.Read());
        }

        [Test]
        public void PaperDisplaysAllTextWithPartialEdit_AndAtSymbol_WhenEditTextIsLongerThanAvailableSpace()
        {
            _paper.Insert(TestSetup.Foo + TestSetup.Space + TestSetup.Space + TestSetup.Foo);
            _paper.Insert(TestSetup.Bar, 4);
            
            Assert.AreEqual(TestSetup.Foo + "ba@oo", _paper.Read());
        }

        [Test]
        public void PaperDisplaysAllTextWithPartialEdit_AndAtSymbol_WhenEditTextIsAddedAtEndOfText()
        {
            _paper.Insert(TestSetup.Foo + TestSetup.Space + TestSetup.Foo);
            _paper.Insert(TestSetup.FooBar, 4);
            
            Assert.AreEqual(TestSetup.Foo + "f@@@ar", _paper.Read());
        }
    }
}