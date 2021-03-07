using Core;
using NUnit.Framework;

namespace CoreTests
{
    public class PencilTests
    {
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
            pencil.Write(TestSetup.FooBar);
            
            Assert.AreEqual(TestSetup.FooBar, _paper.Read());
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
            pencil.Write(TestSetup.Foo);
            
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

        [Test]
        public void PencilIsNotDull_WhenWritingNewLine_AndDurabilityIsOne()
        {
            var pencil = new Pencil(_paper, 1);
            pencil.Write(System.Environment.NewLine);

            Assert.IsFalse(pencil.IsDull());
        }

        [Test]
        public void PaperDisplaysTwoNewLines_WhenWritingTwoNewLines()
        {
            var pencil = new Pencil(_paper, 1);
            pencil.Write(System.Environment.NewLine + System.Environment.NewLine);

            Assert.AreEqual(System.Environment.NewLine + System.Environment.NewLine, _paper.Read());
        }

        [Test]
        public void PaperDisplaysTwoNewLines_AndText_WhenWritingTwoNewLines_AndText()
        {
            var pencil = new Pencil(_paper, 6);
            pencil.Write(System.Environment.NewLine + System.Environment.NewLine + TestSetup.FooBar);

            var expectedText = System.Environment.NewLine + System.Environment.NewLine + TestSetup.FooBar;
            Assert.AreEqual(expectedText, _paper.Read());
        }

        [Test]
        public void PencilIsDull_WhenWritingANewLine_AndText_AndDurabilityIsLow()
        {
            var pencil = new Pencil(_paper, 6);
            pencil.Write(System.Environment.NewLine + TestSetup.FooBar);

            Assert.IsTrue(pencil.IsDull());
        }

        [Test]
        public void PencilIsDull_WhenWritingANewLine_AndOneUppercaseLetter_AndDurabilityIsTwo()
        {
            var pencil = new Pencil(_paper, 2);
            pencil.Write(System.Environment.NewLine + "F");
            
            Assert.IsTrue(pencil.IsDull());
        }

        [Test]
        public void PencilIsNotDull_WhenWritingANewLine_AndASpace_AndDurabilityIsOne()
        {
            var pencil = new Pencil(_paper, 1);
            pencil.Write(System.Environment.NewLine + TestSetup.Space);
            
            Assert.IsFalse(pencil.IsDull());
        }

        [Test]
        public void PencilIsNotDull_WhenSharpened_AfterWritingALetter_AndDurabilityIsOne()
        {
            var pencil = new Pencil(_paper, 1);
            pencil.Write("f");
            pencil.Sharpen();
            
            Assert.IsFalse(pencil.IsDull());
        }

        [Test]
        public void PencilIsDull_WhenSharpened_AfterWritingALetter_AndDurabilityIsOne_AndLengthIsZero()
        {
            var pencil = new Pencil(_paper, 1, 0);
            pencil.Write("f");
            pencil.Sharpen();
            
            Assert.IsTrue(pencil.IsDull());
        }

        [Test]
        public void PencilIsDull_WhenSharpenedTwice_AndLengthIsOne()
        {
            var pencil = new Pencil(_paper, 1);
            pencil.Sharpen();
            pencil.Write("f");
            pencil.Sharpen();
            
            Assert.IsTrue(pencil.IsDull());
        }

        [Test]
        public void PencilIsDull_WhenWritingTwoLetters_AndDurabilityIsOne()
        {
            var pencil = new Pencil(_paper, 1);
            pencil.Write("fo");
            
            Assert.IsTrue(pencil.IsDull());
        }

        [Test]
        public void PaperDisplaysEditedText_WhenPencilEditsText()
        {
            var pencil = new Pencil(_paper, 3);
            _paper.Insert(TestSetup.Foo + TestSetup.Space + TestSetup.Space + TestSetup.Space);
            pencil.Edit(4, TestSetup.Bar);
            
            Assert.AreEqual(TestSetup.FooBar, _paper.Read());
        }
    }
}