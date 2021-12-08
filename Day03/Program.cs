void First()
{
    var lines = File.ReadAllLines("input.txt");
    var totalCount = lines.Length;
    var lineItemsCount = lines[0].ToCharArray().Length;
    var values = new int[lineItemsCount];
    var mid = totalCount / 2M;

    foreach (var vals in lines)
    {
        for (int j = 0; j < vals.Length; j++)
        {
            char val = vals[j];
            if (val == '1') { values[j]++; }
        }
    }

    string binary = new string(values.Select(v => v > mid ? '1' : '0').ToArray());
    string invertedBinary = new string(binary.ToArray().Select(b => b == '1' ? '0' : '1').ToArray());

    int gamma = Convert.ToInt32(binary, 2);
    int epsilon = Convert.ToInt32(invertedBinary, 2);

    Console.WriteLine($"Result: {gamma * epsilon}");
}

string[] GetOxygenGeneratorRating(string[] lines, int index = 0)
{
    var total = lines.Length;
    var counts = lines.Sum(l => l[index] == '1' ? 1 : 0);

    var filter = counts >= total / 2M ? '1' : '0';

    var filtered = lines.Where(l => l[index] == filter).ToArray();

    if (filtered.Length == 1)
    {
        return filtered;
    }
    else
    {
        return GetOxygenGeneratorRating(filtered, index + 1);
    }
}

string[] GetCO2ScubberRating(string[] lines, int index = 0)
{
    var total = lines.Length;
    var counts = lines.Sum(l => l[index] == '1' ? 1 : 0);

    var filter = counts < total / 2M ? '1' : '0';

    var filtered = lines.Where(l => l[index] == filter).ToArray();

    if (filtered.Length == 1)
    {
        return filtered;
    }
    else
    {
        return GetCO2ScubberRating(filtered, index + 1);
    }
}

void Second()
{
    var lines = File.ReadAllLines("input.txt");
    var totalCount = lines.Length;
    var lineItemsCount = lines[0].ToCharArray().Length;
    var values = new int[lineItemsCount];
    var mid = totalCount / 2M;

    var oxygen = GetOxygenGeneratorRating(lines);
    var co2 = GetCO2ScubberRating(lines);

    var oxygenVal = Convert.ToInt32(oxygen[0], 2);
    var co2Val = Convert.ToInt32(co2[0], 2);

    Console.WriteLine($"Result: {oxygenVal * co2Val}");
}

Console.WriteLine("First or second half ? (1 or 2)");
switch (Console.ReadLine() ?? string.Empty)
{
    case "2": Second(); break;
    default: First(); break;
}