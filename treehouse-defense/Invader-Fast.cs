namespace TreehouseDefense
{
    class FastInvader : Invader
    {
        protected override int StepSize {get;} = 2;
        public override int Health { get; protected set; } = 100;
        public override int Power { get; protected set; } = 0;

        public FastInvader(Path path) : base(path)
        {}
    }
}
