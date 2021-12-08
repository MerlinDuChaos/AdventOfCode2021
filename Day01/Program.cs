Console.WriteLine("Input file ?");
var file = Console.ReadLine();

if (!File.Exists(file))
{
    Console.WriteLine("File not found");
    return;
}


void First(string file)
{
    var values = File.ReadAllLines(file).Select(x => int.Parse(x)).ToList();

    int cpt = 0;
    int lastValue = values.First();

    values.Skip(1).ToList().ForEach(x => { if (x > lastValue) { cpt++; } lastValue = x; });


    Console.WriteLine($"Result: {cpt}");
}

void Second(string file)
{
    var values = File.ReadAllLines(file).Select(x => int.Parse(x)).ToList();

    int cpt = 0;
    int lastValue = values.Take(3).Sum();

    for (int i = 1; i <= values.Count - 3; i++)
    {
        var sum = values[i] + values[i + 1] + values[i + 2];
        if (sum > lastValue)
        {
            cpt++;
        }

        lastValue = sum;
    }

    Console.WriteLine($"Result: {cpt}");
}

Console.WriteLine("First or second half ? (1 or 2)");
string choice = Console.ReadLine();

switch (choice)
{
    case "2":
        Second(file);
        break;

    default:
        First(file);
        break;
}
