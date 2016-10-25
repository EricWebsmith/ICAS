using Microsoft.VisualStudio.TestTools.UnitTesting;
using Svg;

namespace Icas.Test
{
    [TestClass]
    public class SvgTest
    {
        [TestMethod]
        public void Convert()
        {
            var sampleDoc = SvgDocument.Open(@"U:\1.svg");
            //sampleDoc.GetElementById<SvgUse>("Commonwealth_Star").Fill = new SvgColourServer(Color.Black);
            sampleDoc.Draw().Save(@"U:\1.png");

        }
    }
}
