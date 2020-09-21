namespace TreehouseDefense
{
	class Tower
	{
		private readonly MapLocation _location;
		private readonly Path _path;
		private int _range;
		private int _power;

		public Tower(MapLocation location, Path path, int range, int power)
		{
			_path = path;
			_range = range;
			_power = power;

			if (path.OnPath(location))
			{
				_location = location;
			} else
			{
				throw new OnPathException($"({location.X},{location.Y}) cannot be placed on the path!");
			}
		}

		public void fireOnInvaders(Invader[] invaders)
		{
			foreach(Invader invader in invaders)
			{
				if( invader.IsActive && _location.InRangeOf(invader.Location, _range) )
				{
					invader.DecreaseHealth(_power);
					break;
				}
			}
		}
	}
}
