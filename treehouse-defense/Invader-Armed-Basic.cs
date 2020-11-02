namespace TreehouseDefense
{
    class BasicArmedInvader : ArmedInvader
    {
        public override int Health { get; protected set; } = 100;
        public override int Power { get; protected set; } = 1;
        public override int Range { get; protected set; } = 2;
        
        public BasicArmedInvader(Path path) : base(path)
        {}
    }
}
