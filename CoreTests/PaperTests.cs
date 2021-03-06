using Core;
using NUnit.Framework;

namespace CoreTests
{
    public class PaperTests
    {
        [Test]
        public void PaperDisplaysText_WhenTextIsInserted()
        {
            var paper = new Paper();
            paper.Insert("foo");

            var paperText = paper.Read();
            
            Assert.AreEqual("foo", paperText);
        }

        [Test]
        public void PaperDisplaysEmptyText_ByDefault()
        {
            var paper = new Paper();
            var paperText = paper.Read();
            
            Assert.AreEqual("", paperText);
        }
    }
}