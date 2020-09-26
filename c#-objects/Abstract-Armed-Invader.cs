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

        public void FireOnTowers(Tower[] towers)
        {
            foreach(Tower tower in towers)
            {
                Console.WriteLine("Invader is aiming...");
                if ( IsSuccessfulShot() )
                {
                    tower.DecreaseHealth(Power);
                    Console.WriteLine("Tower hit by invader!");
                }
            }
        }
    }
}
