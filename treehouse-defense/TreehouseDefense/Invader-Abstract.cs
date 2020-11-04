using System;
namespace TreehouseDefense
{
    abstract class Invader : IInvader
    {
        private readonly Path _path;
        protected int _pathStep = 0;
        protected virtual int StepSize {get;} = 1;
        public Invader(Path path)
        {
            _path = path;
        }
        public MapLocation Location => _path.GetLocationAt(_pathStep);
        public string Honorific => this.GetType().Name;
        public bool IsArmed => Honorific == "StrongArmedInvader" || Honorific == "BasicArmedInvader";
        public abstract int Health { get; protected set; }
        public abstract int Power { get; protected set; }
        // True if the invader has reached the end of the path
        public bool HasScored => (_pathStep >= _path.Length); 
        public bool IsNeutralized => (Health <= 0);
        public bool IsActive => !(IsNeutralized || HasScored);
        public virtual void Move()
        {
            _pathStep += StepSize;
        }
        public virtual void DecreaseHealth(int factor)
        {
            Health -= factor; 
            _pathStep --;
            if ( _pathStep < 0 )
            {
                _pathStep = 1;
            }
        }
        public virtual void FireOnTowers(Tower[] towers)
        {}
    }
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
            return _random.Next(obj.Length);
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
        }
    }
}
