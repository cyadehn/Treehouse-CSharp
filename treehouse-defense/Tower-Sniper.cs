using System;
namespace TreehouseDefense
{
    class SniperTower : Tower
    {
        public override double Accuracy {get;} = 1;
        public override int Range {get;} = 4;
        public override int Power {get;} = 20;

        public SniperTower(MapLocation location, Map map, Path path) : base(location, map, path)
        {}
    }
}
