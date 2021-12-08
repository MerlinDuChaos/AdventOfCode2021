Console.WriteLine("Input file ?");
var file = Console.ReadLine();

if (!File.Exists(file))
{
    Console.WriteLine("File not found");
    return;
}

var lines = File.ReadAllLines(file);

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