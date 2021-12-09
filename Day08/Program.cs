void First()
{
    var values = File.ReadAllLines("input.txt").ToList();

    var lengths = new List<int> { 2, 4, 3, 7 }.ToDictionary(i => i);

    var total = 0;

    foreach (var value in values)
    {
        var output = value.Split("|")[1];
        var outputVals = output.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var amount = outputVals.Count(v => lengths.ContainsKey(v.Length));
        total += amount;
    }

    Console.WriteLine($"Result: {total}");
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
