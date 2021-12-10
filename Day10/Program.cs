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
    
}

Console.WriteLine("First or second half ? (1 or 2)");
switch (Console.ReadLine() ?? string.Empty)
{
    case "2": Second(); break;
    default: First(); break;
}
