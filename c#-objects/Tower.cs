namespace TreehouseDefense
{
	class Tower
	{
		private readonly MapLocation _location;
		private readonly Path _path;

		public Tower(MapLocation location, Path path)
		{
			_path = path;
			if (path.OnPath(location))
			{
				_location = location;
			} else
			{
				throw new OnPathException($"({location.X},{location.Y}) cannot be placed on the path!");
			}
		}
	}
}
