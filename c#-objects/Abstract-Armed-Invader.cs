using System;
namespace TreehouseDefense
{
    abstract class ArmedInvader : Invader
    {
        private static readonly System.Random _random = new System.Random();
        private readonly Path _path;

        protected virtual double Accuracy {get;} = 1;
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

        public override void FireOnTowers(Tower[] towers)
        {
            foreach(Tower tower in towers)
            {
                if ( tower.IsActive )
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
                    }
                    else {
                        Console.WriteLine($"{tower.Honorific}{tower.Coordinates} missed by {Honorific}");
                    }
                }
                break;
            }
        }
    }
}
