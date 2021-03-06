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
    }
}