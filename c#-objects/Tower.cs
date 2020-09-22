using System;
namespace TreehouseDefense
{
    class Tower
    {
        private readonly MapLocation _location;
        private readonly Path _path;
        private int _range;
        private int _power;
        private const double _accuracy = .75;

        private static readonly System.Random _random = new System.Random();

        public Tower(MapLocation location, Path path, int range, int power)
        {
            _path = path;
            _range = range;
            _power = power;

            if (path.OnPath(location))
            {
                _location = location;
            } else
            {
                throw new OnPathException($"({location.X},{location.Y}) cannot be placed on the path!");
            }
        }

        public bool IsSuccessfulShot()
        {
            return _random.NextDouble() < _accuracy;
        }

        public void FireOnInvaders(Invader[] invaders)
        {
            foreach(Invader invader in invaders)
            {
                if( invader.IsActive && _location.InRangeOf(invader.Location, _range) )
                {
                    if (IsSuccessfulShot())
                    {
                        invader.DecreaseHealth(_power);
                        Console.WriteLine("Shot at and hit an invader!");

                        if (invader.IsNeutralized)
                        {
                            Console.WriteLine("Neutralized an invader!");
                        }
                    } else
                    {
                        Console.WriteLine("Shot at and missed an invader!");
                    }
                    break;
                }
            }
        }
    }
}
