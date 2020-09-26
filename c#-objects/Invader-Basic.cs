namespace TreehouseDefense
{
    class BasicInvader : Invader
    {
        public override int Health { get; protected set; } = 100;
        public BasicInvader(Path path) : base(path)
        {}
    }
}
