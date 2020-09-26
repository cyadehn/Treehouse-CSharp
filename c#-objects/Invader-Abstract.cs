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

        //
        //Setter made private
        //User should use DecreaseHealth(factor)
        public abstract int Health { get; protected set; }
        //

        // True if the invader has reached the end of the path
        public bool HasScored => (_pathStep >= _path.Length); 

        public bool IsNeutralized => (Health <= 0);
        public bool IsActive => !(IsNeutralized || HasScored);

        public virtual void Move() => _pathStep += StepSize;
        public virtual void DecreaseHealth(int factor)
        {
          Health -= factor; 
        }
    }
}
