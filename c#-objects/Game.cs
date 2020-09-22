using System;
namespace TreehouseDefense
{
	class Game
	{
		public static void Main()
		{
			Map map = new Map(8, 5);
      
			try {
			  Path path = new Path(
			    new [] {
				new MapLocation(0,2,map),
				new MapLocation(1,2,map),
				new MapLocation(2,2,map),
				new MapLocation(3,2,map),
				new MapLocation(4,2,map),
				new MapLocation(5,2,map),
				new MapLocation(6,2,map),
				new MapLocation(7,2,map),
			    }
			  );

			  Invader[] invaders =
			  {
				  new Invader(path),
				  new Invader(path),
				  new Invader(path),
				  new Invader(path)
			  };

			  Tower[] towers =
			  {
				  new Tower(new MapLocation(1, 3, map), path, 2, 10),
				  new Tower(new MapLocation(1, 3, map), path, 3, 5),
				  new Tower(new MapLocation(1, 3, map), path, 1, 20),
			  };

			  Level level = new Level(invaders)
			  {
				  Towers = towers
			  };

			  bool playerWon = level.Play();

			  Console.WriteLine($"Player " + (playerWon? "won" : "lost"));
			}

			catch (OutOfBoundsException ex)
			{
			  Console.WriteLine(ex);
			}
			catch (TreehouseDefenseException)
			{
			  Console.WriteLine("Unhandled TreehouseDefenseException");
			}
			catch (Exception ex) {
			  Console.WriteLine("Unhandled Exception: " + ex);
			}
		}
	}
}
