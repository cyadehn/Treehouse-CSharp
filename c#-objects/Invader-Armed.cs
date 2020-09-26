using System;
namespace TreehouseDefense
{
    class ArmedInvader : Invader
    {
        private static readonly System.Random _random = new System.Random();

        protected virtual double Accuracy {get;} = .5;
        protected virtual int Power {get;} = 1;
        public override int Health { get; protected set; } = 100;

        public ArmedInvader(Path path) : base(path)
        {}
        
        private bool IsSuccessfulShot()
        {
            return _random.NextDouble() < Accuracy;
        }

        public void FireOnTowers(Tower[] towers)
        {
            foreach(Tower tower in towers)
            {
                if ( IsSuccessfulShot() )
                {
                    tower.DecreaseHealth(Power);
                    Console.WriteLine("Tower hit by invader!");
                }
            }
        }
    }
}
