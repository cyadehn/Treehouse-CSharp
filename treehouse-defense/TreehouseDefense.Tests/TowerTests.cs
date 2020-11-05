using Xunit;

namespace TreehouseDefense.Tests
{
    public class TowerTests
    {
        [Fact()]
        public void FireOnInvadersDecreasesInvadersHealth()
        {
            var map = new Map(3, 3);
            var path = new Path(new MapLocation[] {
                new MapLocation(0,1,map),
                new MapLocation(0,2,map),
                new MapLocation(0,3,map)
                }
            );

            var target = new Tower(new MapLocation(0, 0, map), map, path);

            var invaders = new BasicInvader[]
            {
                new BasicInvader(path),
                new BasicInvader(path)
            };

            target.FireOnInvaders(invaders);

            Assert.All(invaders, i => Assert.Equal(1, i.Health));
        }
    }
}