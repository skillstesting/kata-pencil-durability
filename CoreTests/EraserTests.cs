using Core;
using NUnit.Framework;

namespace CoreTests
{
    public class EraserTests
    {
        private Paper _paper;
        
        [SetUp]
        public void SetUp()
        {
            _paper = new Paper();
        }
        
        [Test]
        public void PaperDisplaysUpdatedText_WhenEraserErasesText()
        {
            var eraser = new Eraser(_paper);
            _paper.Insert(TestSetup.FooBar);
            eraser.Erase(TestSetup.Bar);
            
            Assert.AreEqual(TestSetup.Foo + TestSetup.Space + TestSetup.Space + TestSetup.Space, _paper.Read());
        }

        [Test]
        public void PaperDisplaysOriginalText_WhenEraserErasesText_AndEraserIsDull()
        {
            var eraser = new Eraser(_paper, 0);
            _paper.Insert(TestSetup.FooBar);
            eraser.Erase(TestSetup.Bar);
            
            Assert.AreEqual(TestSetup.FooBar, _paper.Read());
        }
    }
}