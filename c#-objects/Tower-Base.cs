using System;
namespace TreehouseDefense
{
    class Tower
    {
        private readonly MapLocation _location;
        private readonly Map _map;
        private readonly Path _path;

        public virtual double Accuracy {get;} = .75;
        public virtual int Range {get;} = 2;
        public virtual int Power {get;} = 50;
        public virtual int Health {get; protected set;} = 1;
        public string Coordinates => $"({_location.X}, {_location.Y})";
        public string Honorific => this.GetType().Name;

        private static readonly System.Random _random = new System.Random();

        public Tower(MapLocation location, Map map, Path path) {
            
            _map = map;
            _path = path;
            
            if (!map.IsOnMap(location))
            {
                throw new OutOfBoundsException($"({location.X},{location.Y}) is not on the map!");
            }
            else if (!path.IsOnPath(location))
            {
                _location = location;
            }
            else
            {
                throw new OnPathException($"({location.X},{location.Y}) cannot be placed on the path!");
            }
        }

        public bool IsActive => Health > 0;
        private bool IsSuccessfulShot()
        {
            return _random.NextDouble() < Accuracy;
        }

        public void FireOnInvaders(IInvader[] invaders)
        {
            foreach(IInvader invader in invaders)
            {
                if( invader.IsActive && _location.InRangeOf(invader.Location, Range) )
                {
                    if (IsSuccessfulShot())
                    {
                        invader.DecreaseHealth(Power);
                        //Console.WriteLine($"SUCCESS : Shot and hit {invader.GetType().Name}!");
                        Console.Write($"|x|");

                        if (invader.IsNeutralized)
                        {
                            Console.WriteLine($"\n+1EXP : {invader.Honorific} neutralized!\n");
                        }
                    } else
                    {
                        Console.Write("|o|");
                    }
                    break;
                }
            }
        }
        
        public void DecreaseHealth( int factor )
        {
            Health -= factor;
        }
    }
}
