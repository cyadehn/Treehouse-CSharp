using System;
namespace TreehouseDefense
{
    class StrongTower : Tower
    {
        public override int Power {get;} = 75;
        public override int Health {get; protected set;} = 2;

        public StrongTower(MapLocation location, Map map, Path path) : base(location, map, path)
        {}
    }
}
