namespace TreehouseDefense
{
    interface IMappable
    {
        MapLocation Location { get; }
    }
    
    interface IMoveable
    {
        void Move();
    }
    
    interface IInvader : IMappable, IMoveable
    {
        string Honorific { get; }
        int Health { get; }
        bool HasScored {get;}
        bool IsArmed { get; }
        bool IsNeutralized { get; }
        bool IsActive { get; }

        void DecreaseHealth(int factor);
        void FireOnTowers(Tower[] towers);
    }
}
