using Core;
using NUnit.Framework;

namespace CoreTests
{
    public class PencilTests
    {
        private const string FooBar = "foobar";
        private Paper _paper;
        
        [SetUp]
        public void SetUp()
        {
            _paper = new Paper();
        }
        
        [Test]
        public void PaperDisplaysText_WhenPencilWritesText()
        {
            var pencil = new Pencil(_paper);
            pencil.Write(FooBar);
            
            Assert.AreEqual(FooBar, _paper.Read());
        }
    }
}