namespace TreehouseDefense
{
    class BasicInvader : Invader
    {
        public override int Health { get; protected set; } = 100;
        public override int Power { get; protected set; } = 0;

        public BasicInvader(Path path) : base(path)
        {}
    }
}
