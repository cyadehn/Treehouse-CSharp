namespace TreehouseDefense
{
    public class BasicInvader : Invader
    {
        public override int Health { get; protected set; } = 100;
        public override int Power { get; protected set; } = 0;
        public BasicInvader(Path path) : base(path)
        {}
    }
    public class FastInvader : Invader
    {
        protected override int StepSize {get;} = 2;
        public override int Health { get; protected set; } = 100;
        public override int Power { get; protected set; } = 0;
        public FastInvader(Path path) : base(path)
        {}
    }
    public class ShieldedInvader : Invader
    {
        public override int Health { get; protected set; } = 100;
        public override int Power { get; protected set; } = 0;
        private static System.Random _random = new System.Random();
        public ShieldedInvader(Path path) : base(path)
        {}
        public override void DecreaseHealth(int factor)
        {
            if (_random.NextDouble() < .5)
            {
                base.DecreaseHealth(factor);
            }  
        }
    }
    public class StrongArmedInvader : ArmedInvader
    {
        public override int Health { get; protected set; } = 100;
        public override int Power { get; protected set; } = 2;
        public override int Range { get; protected set; } = 3;
        protected override double Accuracy {get;} = .25;
        public StrongArmedInvader(Path path) : base(path)
        {}
    }
    public class BasicArmedInvader : ArmedInvader
    {
        public override int Health { get; protected set; } = 100;
        public override int Power { get; protected set; } = 1;
        public override int Range { get; protected set; } = 2;
        public BasicArmedInvader(Path path) : base(path)
        {}
    }
    public class ResurrectingInvader : IInvader
    {
        private BasicInvader _regeneration1;
        private StrongArmedInvader _regeneration2;
        public MapLocation Location => 
            _regeneration1.IsNeutralized ? 
            _regeneration2.Location : _regeneration1.Location;
        public string Honorific => this.GetType().Name;
        public bool IsArmed => Honorific == "StrongArmedInvader" || Honorific == "BasicArmedInvader";
        public int Health => 
            _regeneration1.IsNeutralized ? 
            _regeneration2.Health : _regeneration1.Health;
        public int Power => 
            _regeneration1.IsNeutralized ? 
            _regeneration2.Power : _regeneration1.Power;
        public bool HasScored => 
            _regeneration1.HasScored || _regeneration2.HasScored;
        public bool IsNeutralized => _regeneration1.IsNeutralized && _regeneration2.IsNeutralized;
        public bool IsActive => !(IsNeutralized || HasScored);
        public ResurrectingInvader(Path path)
        {
            _regeneration1 = new BasicInvader(path);
            _regeneration2 = new StrongArmedInvader(path);
        }
        public void Move()
        {
            _regeneration1.Move();
            _regeneration2.Move();
        }
        public void DecreaseHealth(int factor)
        {
            if ( !_regeneration1.IsNeutralized )
            {
                _regeneration1.DecreaseHealth(factor);
            }
            else
            {
                _regeneration2.DecreaseHealth(factor);
            }
        }
        public void FireOnTowers(Tower[] towers)
        {
            if ( _regeneration1.IsNeutralized )
            {
                _regeneration2.FireOnTowers(towers);
            } 
            else
            {
                _regeneration1.FireOnTowers(towers);
            }
        }
    }
}
