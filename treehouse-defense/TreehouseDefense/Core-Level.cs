namespace TreehouseDefense
{
    class Level
    {
        private readonly IInvader[] _invaders;
        public Tower[] Towers { get; set; }
        public Level(IInvader[] invaders)
        {
            _invaders = invaders;
        }
        public bool Play()
        {
            // Run until all invaders are neutralized or an invader reaches the end
            int remainingInvaders = _invaders.Length;
            while( remainingInvaders > 0 )
            {
                // Each tower has opportunity to fire on invaders
                foreach( Tower tower in Towers )
                {
                    tower.FireOnInvaders(_invaders);
                }
                // Count and move the invaders that are still active
                remainingInvaders = 0;
                foreach( IInvader invader in _invaders )
                {
                    if( invader.IsActive )
                    {
                        invader.Move();
                        if( invader.HasScored )
                        {
                            return false;
                        }
                        invader.FireOnTowers(Towers);
                        remainingInvaders++;
                    }
                }
            }
            return true;
        }
    }
}
