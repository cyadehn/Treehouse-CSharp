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
        public void DistanceToWithPythagoreanTriple()
        {
            var point = new Point(3,4);
            // "target" since this is the class instance being tested
            var target = new Point(0,0);
            var expected = 5.0;
            var actual = target.DistanceTo(point);
            // third parameter will set the level of precision -- due to floating point comparison here
            Assert.Equal(expected, actual, 2);
        }
        [Fact()]
        public void DistanceToPointAtSamePosition()
        {
            var point = new Point(3,4);
            var target = new Point(3,4);
            var expected = 0.0;
            var actual = target.DistanceTo(point);
            Assert.Equal(expected, actual, 2);

        }
        [Fact()]
        public void EqualsWithDifferentInstances()
        {
            var point1 = new Point(3,4);
            var point2 = new Point(3,4);
            bool result = point1.Equals(point2);
            Assert.True(result);

        }
    }
}
