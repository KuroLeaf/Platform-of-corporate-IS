namespace WpfShapesHexagonUnitTestProject
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WpfShapesHexagon;
    using System.Windows.Media;

    [TestClass]
    public class HexagonModelTesting
    {
        [TestMethod]
        public void ConstructorTesting()
        {
            var expectedPoints = new PointCollection();
            var expectedStroke = Brushes.Black;
            var expectedFill = Brushes.AliceBlue;
            var expectedNumber = 2;
            var expectedLeft = 100;
            var expectedTop = 100;
            HexagonModel test = new HexagonModel()
            {
                Points = expectedPoints,
                Stroke = expectedStroke,
                Fill = expectedFill,
                Number = expectedNumber,
                Left = expectedLeft,
                Top = expectedTop
            };
            Assert.AreEqual(expectedPoints.Count, test.Points.Count);
            Assert.AreEqual(expectedStroke, test.Stroke);
            Assert.AreEqual(expectedFill, test.Fill);
            Assert.AreEqual(expectedNumber, test.Number);
            Assert.AreEqual(expectedLeft, test.Left);
            Assert.AreEqual(expectedTop, test.Top);
        }
    }
}
