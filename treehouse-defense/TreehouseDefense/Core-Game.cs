using System;
namespace TreehouseDefense
{
	class Game
	{
		public static void Main()
		{
			Map map = new Map(8, 5);
			try 
			{
				Path path = new Path(
						new [] {
						new MapLocation(0,2,map),
						new MapLocation(1,2,map),
						new MapLocation(2,2,map),
						new MapLocation(3,2,map),
						new MapLocation(4,2,map),
						new MapLocation(5,2,map),
						new MapLocation(6,2,map),
						new MapLocation(7,2,map)});
				IInvader[] invaders =
				{
					new ShieldedInvader(path),
					new FastInvader(path),
					new BasicArmedInvader(path),
					new ResurrectingInvader(path),
					new ResurrectingInvader(path),
					new BasicInvader(path),
				};
				Tower[] towers = new Tower[]
				{
					new Tower(new MapLocation(1, 3, map), map, path),
						new Tower(new MapLocation(4, 3, map), map, path),
						new Tower(new MapLocation(2, 1, map), map, path),
						new StrongTower(new MapLocation(7, 3, map), map, path),
						new SniperTower(new MapLocation(3, 3, map), map, path)
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
			catch (TreehouseDefenseException ex)
			{
				Console.WriteLine($"Unhandled TreehouseDefenseException: {ex}");
			}
			catch (Exception ex) 
			{
				Console.WriteLine("Unhandled Exception: " + ex);
			}
		}
	}
}
