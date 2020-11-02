using System;
namespace TreehouseDefense
{
    abstract class ArmedInvader : Invader
    {
        private static readonly System.Random _random = new System.Random();
        private readonly Path _path;

        protected virtual double Accuracy {get;} = 1;
        public abstract int Range { get; protected set; }
        public override abstract int Health { get; protected set; }
        public override abstract int Power { get; protected set; }

        public ArmedInvader(Path path) : base(path)
        {
            _path = path;
        }
        
        private bool IsSuccessfulShot()
        {
            return _random.NextDouble() < Accuracy;
        }

        private int ArrayIndex(object[] obj)
        {
            return System.Math.Ceiling(int32.Parse(_random.Next(obj.Length)));
        }

        public override void FireOnTowers(Tower[] towers)
        {
            int index = ArrayIndex(towers);
            Tower tower = towers[index]; 
            
            while ( tower.IsActive  )
            {
                Console.Write("\nINCOMING!!!");
                if ( IsSuccessfulShot() )
                {
                    tower.DecreaseHealth(Power);
                    Console.WriteLine($"{tower.Honorific} hit by invader! Health left: {tower.Health}");

                    if ( !tower.IsActive )
                    {
                        Console.WriteLine($"{tower.Honorific}{tower.Coordinates} has fallen.\n");
                    }

                    return;
                }
                else 
                {
                    Console.WriteLine($"{tower.Honorific}{tower.Coordinates} missed by {Honorific}");
                    return;
                }
            }
            index = ArrayIndex(towers);
            continue;
        }
    }
}
