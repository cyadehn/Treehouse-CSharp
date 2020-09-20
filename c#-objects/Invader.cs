namespace TreehouseDefense
{
	class Invader
  { 
      private readonly Path _path;
      private int _pathStep = 0;

      public Invader(Path path)
      {
          _path = path;
      }
      
      public MapLocation Location => _path.GetLocationAt(_pathStep);
      
      //
      //Setter made private
      //User should use DecreaseHealth(factor)
      public int Health { get; private set; } = 100;
      //
      
      // True if the invader has reached the end of the path
      public bool HasScored => (_pathStep >= _path.Length); 

	public bool IsNeutralized => (Health <= 0);
	public bool IsActive => !(IsNeutralized || HasScored);
    
      public void Move() => _pathStep += 1;
      public void DecreaseHealth(int factor)
      {
          Health -= factor; 
      }
	}
}
