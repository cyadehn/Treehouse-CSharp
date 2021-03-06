using System;
using System.Linq;
namespace TreehouseDefense
{
  public class Map 
  {
    public readonly int Width;
    public readonly int Height;
    public Map( int width, int height ) 
    {
      {
        if (width > 0 && height > 0)
        {
          Width = width;
          Height = height;
        }
        else
        {
          throw new ArgumentOutOfRangeException();
        }
      }
    }
    public bool IsOnMap(Point point) 
    {
      return point.X >= 0 && point.X < Width && 
        point.Y >= 0 && point.Y < Height;
    }
  }
  public class MapLocation : Point 
  {
    public MapLocation(int x, int y, Map map) : base(x,y) 
    {
      if (!map.IsOnMap(this)) 
      {
        throw new OutOfBoundsException($"{x}, {y} is outside the boundaries of the map!");
      }
    }
    public bool InRangeOf(MapLocation location, int range)
    {
      return DistanceTo(location) <= range;
    }
  }
  public class Path
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
    public bool IsOnPath(MapLocation location) => _path.Contains(location);
  }
  public class Point
  {
    public readonly int X;
    public readonly int Y;
    public Point(int x, int y)
    {
      X = x;
      Y = y;
    }
    public double DistanceTo(int x, int y) 
    {
      int xDiff = X - x;
      int yDiff = Y - y;
      int xDiffSquared = xDiff * xDiff;
      int yDiffSquared = yDiff * yDiff;
      return (double)Math.Sqrt(xDiffSquared + yDiffSquared);
    }
    public double DistanceTo(Point point) 
    {
      return DistanceTo(point.X, point.Y);
    }
    public override bool Equals(object obj)
    {
      if (!(obj is Point))
      {
        return false;
      }
      Point that = obj as Point;
      return this.X == that.X && this.Y == that.Y;
    }
    public override int GetHashCode()
    {
      return X.GetHashCode() * 31 + Y.GetHashCode() * 29;
    }
  }
}
