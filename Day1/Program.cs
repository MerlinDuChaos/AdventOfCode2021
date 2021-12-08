Console.WriteLine("Input file ?");
var file = Console.ReadLine();

if (!File.Exists(file))
{
    Console.WriteLine("File not found");
    return;
}

var values = File.ReadAllLines(file).Select(x => int.Parse(x)).ToList();

int cpt = 0;
int lastValue = values.First();

values.Skip(1).ToList().ForEach(x => { if (x > lastValue) { cpt++; } lastValue = x; });


Console.WriteLine($"Result: {cpt}");