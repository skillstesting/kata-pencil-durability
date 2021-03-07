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
            var pencil = new Pencil(_paper, 6);
            pencil.Write(FooBar);
            
            Assert.AreEqual(FooBar, _paper.Read());
        }

        [Test]
        public void PencilIsDull_WhenWritingOneLowercaseLetter_AndDurabilityIsOne()
        {
            var pencil = new Pencil(_paper, 1);
            pencil.Write("f");
            
            Assert.IsTrue(pencil.IsDull());
        }

        [Test]
        public void PencilIsDull_WhenWritingOneUppercaseLetter_AndDurabilityIsTwo()
        {
            var pencil = new Pencil(_paper, 2);
            pencil.Write("F");
            
            Assert.IsTrue(pencil.IsDull());
        }

        [Test]
        public void PaperDisplaysPartialTextWithASpace_WhenWritingText_AndDurabilityIsLow()
        {
            var pencil = new Pencil(_paper, 2);
            pencil.Write("foo");
            
            Assert.AreEqual("fo ", _paper.Read());
        }

        [Test]
        public void PencilIsNotDull_WhenWritingASpace_AndDurabilityIsOne()
        {
            var pencil = new Pencil(_paper, 1);
            pencil.Write(" ");
            
            Assert.IsFalse(pencil.IsDull());
        }

        [Test]
        public void PaperDisplaysNewLine_WhenWritingNewLine()
        {
            var pencil = new Pencil(_paper, 1);
            pencil.Write(System.Environment.NewLine);
            
            Assert.AreEqual(System.Environment.NewLine, _paper.Read());
        }
    }
}