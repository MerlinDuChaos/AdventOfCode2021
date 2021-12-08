
void First()
{
    var lines = File.ReadAllLines("input.txt");
    int numberOfDays = 80;

    var data = lines[0].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToList();

    for (int day = 0; day < numberOfDays; day++)
    {
        int actualCount = data.Count;

        for (int i = 0; i < actualCount; i++)
        {
            data[i]--;

            if (data[i] == -1)
            {
                data[i] = 6;
                data.Add(8);
            }

        }
    }

    Console.WriteLine($"Result: {data.Count}");
}

void Second()
{
    var lines = File.ReadAllLines("input.txt");
    int numberOfDays = 256;

    var data = lines[0].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToList();

    var dict = Enumerable.Range(0, 9).ToDictionary(i => i, i => 0L);

    foreach (var group in data.GroupBy(d => d))
    {
        dict[group.Key] = group.Count();
    }

    for (int day = 0; day < numberOfDays; day++)
    {
        var newDict = Enumerable.Range(0, 9).ToDictionary(i => i, i => 0L);

        for (int i = 8; i > 0; i--)
        {
            newDict[i - 1] = dict[i];
        }

        newDict[6] += dict[0];
        newDict[8] += dict[0];

        dict = newDict;
    }

    Console.WriteLine($"Result: {dict.Sum(d => d.Value)}");
}

Console.WriteLine("First or second half ? (1 or 2)");
switch (Console.ReadLine() ?? string.Empty)
{
    case "2": Second(); break;
    default: First(); break;
}
