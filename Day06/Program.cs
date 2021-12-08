
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
}

Console.WriteLine("First or second half ? (1 or 2)");
switch (Console.ReadLine() ?? string.Empty)
{
    case "2": Second(); break;
    default: First(); break;
}
