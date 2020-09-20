namespace TreehouseDefense
{
	class Path
	{
		private readonly MapLocation[] _path;

		public int Length => _path.Length;

		public Path(MapLocation[] path)
		{
		  _path = path; 
		}

		public MapLocation GetLocationAt(int pathStep)
		{
		  return (pathStep < _path.Length) ? _path[pathStep] : null;
		}
		
		public bool OnPath(MapLocation location)
		{
			return location.Y == _path[0].Y ? true : false;
		}
	}
}
