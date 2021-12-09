void First()
{
    var values = File.ReadAllLines("input.txt").ToList();
    var table = values.Select(line =>
    {
        return line.ToCharArray().Select(i => int.Parse(i.ToString())).ToArray();
    }).ToArray();

    var lowPoints = new List<int>();

    for (int y = 0; y < table.Length; y++)
    {
        for (int x = 0; x < table[y].Length; x++)
        {
            int val = table[y][x];

            if (y > 0)
            {
                int up = table[y - 1][x];
                if (up <= val)
                {
                    continue;
                }
            }

            if (x < table[y].Length - 1)
            {
                int right = table[y][x + 1];
                if (right <= val)
                {
                    continue;
                }
            }
            
            if (y < table.Length - 1)
            {
                int bottom = table[y + 1][x];
                if (bottom <= val)
                {
                    continue;
                }
            }

            if (x > 0)
            {
                int left = table[y][x - 1];
                if (left <= val)
                {
                    continue;
                }
            }

            // it's a low point !
            lowPoints.Add(val + 1);
        }
    }

    Console.WriteLine($"Result : {lowPoints.Sum()}");
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
