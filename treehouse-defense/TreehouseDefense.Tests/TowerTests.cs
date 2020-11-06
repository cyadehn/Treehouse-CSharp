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
                new MapLocation(0,0,map),
                new MapLocation(0,0,map),
                new MapLocation(0,0,map)
                }
            );

            var target = new Tower(new MapLocation(2, 1, map), map, path);

            var invaders = new BasicInvader[]
            {
                new BasicInvader(path),
                new BasicInvader(path)
            };

            var expected = new BasicInvader(path).Health - target.Power;

            foreach ( IInvader invader in invaders )
            {
                var startingHealth = invader.Health;
                while (invader.Health == startingHealth)
                {
                    target.FireOnInvaders(invader);
                }
            }

            Assert.All(invaders, i => Assert.Equal(expected, i.Health));
        }
    }
}