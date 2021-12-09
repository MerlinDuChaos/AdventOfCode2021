void First()
{
    var values = File.ReadAllText("input.txt")
                     .Split(",", StringSplitOptions.RemoveEmptyEntries)
                     .Select(i => int.Parse(i))
                     .ToList();

    var minFuel = int.MaxValue;

    for (int i = values.Min(); i < values.Max(); i++)
    {
        int fuel = 0;
        foreach (var value in values)
        {
            fuel += Math.Abs(value - i);
        }

        if (fuel < minFuel)
        {
            minFuel = fuel;
        }
    }

    Console.WriteLine($"Result: {minFuel}");
}

void Second()
{
   
}

Console.WriteLine("First or second half ? (1 or 2)");
switch (Console.ReadLine() ?? string.Empty)
{
    case "2": Second(); break;
    default: First(); break;
}
