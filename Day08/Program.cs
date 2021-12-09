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

string SortLetters(string input)
{
    return new string(input.OrderBy(i => i).ToArray());
}

Dictionary<string, int> GeneratePatterns(string[] input)
{
    var inputCopy = input.ToList();
    Dictionary<char, char> letters = new Dictionary<char, char>();

    string seven = input.Single(i => i.Length == 3);
    string one = input.Single(i => i.Length == 2);
    string eight = input.Single(i => i.Length == 7);
    string four = input.Single(i => i.Length == 4);

    inputCopy.Remove(seven);
    inputCopy.Remove(one);
    inputCopy.Remove(eight);
    inputCopy.Remove(four);

    // A is seven minus one
    char a = seven.Except(one).Single();
    letters.Add('a', a);

    // 6 is entry of 6 characters not containing one
    var length6 = input.Where(i => i.Length == 6).ToList();
    string six = string.Empty;
    foreach (var entry in length6)
    {
        if (!one.All(i => entry.Contains(i)))
        {
            six = entry;
            break;
        }
    }

    length6.Remove(six);
    inputCopy.Remove(six);

    // Now we have six => we can determine C = eight - six
    char c = eight.Except(six).Single();
    letters.Add('c', c);

    // Now we have a & c, f = seven - a - c
    char f = seven.Except(new [] { letters['a']}).Except(new [] { letters['c'] }).Single();
    letters.Add('f', f);

    // Nine is entry of 6 characters (except six) which contains all of four
    string nine = four.All(i => length6[0].Contains(i)) ? length6[0] : length6[1];
    length6.Remove(nine);
    inputCopy.Remove(nine);

    // What's left in lengt6 is zero
    string zero = length6[0];
    inputCopy.Remove(zero);

    // E is eight - nine
    char e = eight.Except(nine).Single();
    letters.Add('e', e);

    // two is the only left containing e
    string two = inputCopy.Single(i => i.Contains(letters['e']));
    inputCopy.Remove(two);

    // three is the only left containing c
    string three = inputCopy.Single(i => i.Contains(letters['c']));
    inputCopy.Remove(three);

    // Last one is five
    string five = inputCopy[0];

    Dictionary<string, int> patterns = new()
    {
        [SortLetters(zero)] = 0,
        [SortLetters(one)] = 1,
        [SortLetters(two)] = 2,
        [SortLetters(three)] = 3,
        [SortLetters(four)] = 4,
        [SortLetters(five)] = 5,
        [SortLetters(six)] = 6,
        [SortLetters(seven)] = 7,
        [SortLetters(eight)] = 8,
        [SortLetters(nine)] = 9
    };

    return patterns;
}

void Second()
{
    var values = File.ReadAllLines("input.txt").ToList();

    int sum = 0;

    foreach (var value in values)
    {
        var parts = value.Split("|");
        var patternsVals = parts[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var outputVals = parts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
        var patterns = GeneratePatterns(patternsVals);

        string txtVal = $"{patterns[SortLetters(outputVals[0])]}{patterns[SortLetters(outputVals[1])]}{patterns[SortLetters(outputVals[2])]}{patterns[SortLetters(outputVals[3])]}";
        int val = int.Parse(txtVal);
        sum += val;
    }

    Console.WriteLine($"Result : {sum}");
}

Console.WriteLine("First or second half ? (1 or 2)");
switch (Console.ReadLine() ?? string.Empty)
{
    case "2": Second(); break;
    default: First(); break;
}
