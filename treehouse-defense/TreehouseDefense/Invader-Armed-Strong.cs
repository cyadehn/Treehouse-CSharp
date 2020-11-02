using System;
namespace TreehouseDefense
{
    class StrongArmedInvader : ArmedInvader
    {
        public override int Health { get; protected set; } = 100;
        public override int Power { get; protected set; } = 2;
        public override int Range { get; protected set; } = 3;
        protected override double Accuracy {get;} = .25;

        public StrongArmedInvader(Path path) : base(path)
        {}
    }
}
