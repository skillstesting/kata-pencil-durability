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
        public void PaperDisplaysText_WhenTextIsInserted()
        {
            _paper.Insert("foo");
            
            Assert.AreEqual("foo", _paper.Read());
        }

        [Test]
        public void PaperDisplaysEmptyText_ByDefault()
        {
            Assert.AreEqual("", _paper.Read());
        }

        [Test]
        public void PaperDisplaysAllText_WhenTextIsInsertedTwice()
        {
            _paper.Insert("foo");
            _paper.Insert("bar");
            
            Assert.AreEqual("foobar", _paper.Read());
        }

        [Test]
        public void PaperDisplaysTextWithOneSpace_WhenTextWithOneLetterIsRemoved()
        {
            _paper.Insert("F");
            _paper.Remove("F");
            
            Assert.AreEqual(" ", _paper.Read());
        }
    }
}