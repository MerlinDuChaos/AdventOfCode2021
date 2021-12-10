void First()
{
    var lines = File.ReadAllLines("input.txt").ToList();

    var illegalChars = new List<char>();
    var opening = new List<char> { '(', '[', '{', '<' };
    var closing = new List<char> { ')', ']', '}', '>' };

    foreach (var line in lines)
    {
        Stack<char> openingStack = new();
        foreach (var c in line)
        {
            if (opening.Contains(c))
            {
                openingStack.Push(c);
            }
            else if (closing.Contains(c))
            {
                // check if closing char corresponds to last opening
                var lastOpening = openingStack.Pop();

                if (opening.IndexOf(lastOpening) != closing.IndexOf(c))
                {
                    illegalChars.Add(c);
                    break;
                }
            }
        }
    }

    var total = illegalChars.Sum(i =>
    {
        switch (i)
        {
            case ')': return 3;
            case ']': return 57;
            case '}': return 1197;
            case '>': return 25137;
            default: throw new Exception();
        }
    });

    Console.WriteLine($"Result: {total}");
}

void Second()
{
    var lines = File.ReadAllLines("input.txt").ToList();

    var opening = new List<char> { '(', '[', '{', '<' };
    var closing = new List<char> { ')', ']', '}', '>' };

    var completionSequences = new List<string>();

    List<long> totals = new List<long>();

    // Get valid lines
    foreach (var line in lines)
    {
        Stack<char> openingStack = new();
        bool corrupted = false;
        foreach (var c in line)
        {
            if (opening.Contains(c))
            {
                openingStack.Push(c);
            }
            else if (closing.Contains(c))
            {
                // check if closing char corresponds to last opening
                var lastOpening = openingStack.Pop();

                if (opening.IndexOf(lastOpening) != closing.IndexOf(c))
                {
                    corrupted = true;
                    break;
                }
            }
        }

        if (!corrupted)
        {
            long total = 0;

            // Get completion sequence
            while (openingStack.Count > 0)
            {
                var x = openingStack.Pop();
                var v = opening.IndexOf(x);

                total = total * 5;
                total = total + v + 1;
            }

            totals.Add(total);
        }
    }

    totals = totals.OrderBy(x => x).ToList();
    var middleScore = totals[(totals.Count / 2)];

    Console.WriteLine($"Result : {middleScore}");
}

Console.WriteLine("First or second half ? (1 or 2)");
switch (Console.ReadLine() ?? string.Empty)
{
    case "2": Second(); break;
    default: First(); break;
}
