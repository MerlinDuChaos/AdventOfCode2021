void First()
{
    var lines = File.ReadAllLines("input.txt");

    int horizontalPos = 0;
    int depth = 0;

    foreach (var line in lines)
    {
        var parts = line.Split(" ");
        var amount = int.Parse(parts[1]);

        switch (parts[0])
        {
            case "forward":
                horizontalPos += amount;
                break;

            case "down":
                depth += amount;
                break;

            case "up":
                depth -= amount;
                break;
        }
    }

    Console.WriteLine($"Result: {horizontalPos * depth}");
}

void Second()
{
    var lines = File.ReadAllLines("input.txt");

    int horizontalPos = 0;
    int depth = 0;
    int aim = 0;

    foreach (var line in lines)
    {
        var parts = line.Split(" ");
        var amount = int.Parse(parts[1]);

        switch (parts[0])
        {
            case "forward":
                horizontalPos += amount;
                depth += aim * amount;
                break;

            case "down":
                aim += amount;
                break;

            case "up":
                aim -= amount;
                break;
        }
    }

    Console.WriteLine($"Result: {horizontalPos * depth}");
}

Console.WriteLine("First or second half ? (1 or 2)");
switch (Console.ReadLine() ?? string.Empty)
{
    case "2": Second(); break;
    default: First(); break;
}