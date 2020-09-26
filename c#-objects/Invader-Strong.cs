using System;
namespace TreehouseDefense
{
    class StrongInvader : ArmedInvader
    {
        public override int Health { get; protected set; } = 100;
        protected override double Accuracy {get;} = .25;
        protected override int Power {get;} = 2;

        public StrongInvader(Path path) : base(path)
        {}
    }
}
