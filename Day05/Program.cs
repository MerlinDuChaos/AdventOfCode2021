Console.WriteLine("Input file ?");
var file = Console.ReadLine();

if (!File.Exists(file))
{
    Console.WriteLine("File not found");
    return;
}

var allPoints = new List<Pt>();

var lines = File.ReadAllLines(file);

foreach (var line in lines)
{
    var pts = new Line(line);
    allPoints.AddRange(pts.GetAllPoints());
}

var groups = allPoints.GroupBy(p => p).Where(g => g.Count() > 1);

Console.WriteLine($"Result: {groups.Count()}");

class Line
{
    public Line(string input)
    {
        var points = input.Split(" -> ");
        Pt1 = new Pt(points[0]);
        Pt2 = new Pt(points[1]);
    }

    public Pt Pt1 { get; set; }
    public Pt Pt2 { get; set; }

    public IEnumerable<Pt> GetAllPoints()
    {
        if (Pt1.X == Pt2.X) // Same column
        {
            return GenerateColumnPoints(Pt1.X, Math.Min(Pt1.Y, Pt2.Y), Math.Max(Pt1.Y, Pt2.Y));
        }
        else if (Pt1.Y == Pt2.Y) // Same row
        {
            return GenerateRowPoints(Pt1.Y, Math.Min(Pt1.X, Pt2.X), Math.Max(Pt1.X, Pt2.X));

        }
        else // diagonal
        {
            return GenerateDiagonalPoints(Pt1, Pt2);
        }
    }

    private IEnumerable<Pt> GenerateDiagonalPoints(Pt pt1, Pt pt2)
    {
        // Check if really 45° => xEnd - xStart == yEnd - yStart
        if (Math.Abs(pt1.X - pt2.X) != Math.Abs(pt1.Y - pt2.Y))
        {
            return Enumerable.Empty<Pt>();  
        }

        var increment = Math.Abs(pt1.X - pt2.X);
        var ret = new List<Pt>();

        if (pt1.X > pt2.X) // pt2 left
        {
            if (pt1.Y > pt2.Y) // pt2 Top-left
            {
                for (int i = 0; i <= increment; i++)
                {
                    ret.Add(new Pt(pt2.X + i, pt2.Y + i));
                }
            }
            else // pt2 bottom-left
            {
                for (int i = 0; i <= increment; i++)
                {
                   ret.Add(new Pt(pt2.X + i, pt2.Y - i));
                }
            }
        }
        else // pt2 right
        {
            if (pt1.Y > pt2.Y) // pt2 Top-right
            {
                for (int i = 0; i <= increment; i++)
                {
                    ret.Add(new Pt(pt1.X + i, pt1.Y - i));
                }
            }
            else // pt2 bottom-right
            {
                for (int i = 0; i <= increment; i++)
                {
                    ret.Add(new Pt(pt1.X + i, pt1.Y + i));
                }
            }
        }

        return ret;
    }

    private IEnumerable<Pt> GenerateColumnPoints(int x, int yStart, int yEnd)
    {
        for (int i = yStart; i <= yEnd; i++)
        {
            yield return new Pt(x, i);
        }
    }

    private IEnumerable<Pt> GenerateRowPoints(int y, int xStart, int xEnd)
    {
        for (int i = xStart; i <= xEnd; i++)
        {
            yield return new Pt(i, y);
        }
    }
}

class Pt : IEquatable<Pt>
{
    public int X { get; set; }
    public int Y { get; set; }

    public Pt(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Pt(string input)
    {
        var pts = input.Split(",");
        X = int.Parse(pts[0]);
        Y = int.Parse(pts[1]);
    }

    public bool Equals(Pt? other)
    {
        return other?.X == X && other?.Y == Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}