using Xunit;
using static TreehouseDefense.Point;

namespace TreehouseDefense.Tests
{
    public class PointTests
    {
        [Fact()]
        public void PointTest()
        {
            // prepare
            int x = 5;
            int y = 6;
            //act
            var point = new Point(x,y);
            //assert
            Assert.Equal(x,point.X);
            Assert.Equal(y,point.Y);
        }
        [Fact()]
        public void DistanceToTest()
        {
            Assert.True(false, "This test needs an implementation");
        }
    }
}
