void First()
{
    var lines = new Queue<string>(File.ReadAllLines("input.txt").Where(l => !string.IsNullOrWhiteSpace(l)));
    var draws = lines.Dequeue().Split(',').Select(i => int.Parse(i)).ToList();
    var boards = new List<Board>();

    while (lines.Any())
    {
        var values = Enumerable.Range(0, 5).Select(i => lines.Dequeue()).ToArray();
        boards.Add(new Board(values));
    }

    Board? winningBoard = null;
    int lastDraw = 0;

    foreach (int draw in draws)
    {
        lastDraw = draw;

        foreach (var b in boards)
        {
            if (b.TryCheck(draw) && b.HasBingo())
            {
                winningBoard = b;
                break;
            }
        };

        if (winningBoard != null)
        {
            break;
        }
    }

    var score = winningBoard?.GetScore(lastDraw);

    Console.WriteLine($"Result: {score}");
}

void Second()
{
    var lines = new Queue<string>(File.ReadAllLines("input.txt").Where(l => !string.IsNullOrWhiteSpace(l)));
    var draws = lines.Dequeue().Split(',').Select(i => int.Parse(i)).ToList();
    var boards = new List<Board>();

    while (lines.Any())
    {
        var values = Enumerable.Range(0, 5).Select(i => lines.Dequeue()).ToArray();
        boards.Add(new Board(values));
    }

    Board? winningBoard = null;
    int lastDrawWhenWinningBoard = 0;

    foreach (int draw in draws)
    {
        foreach (var b in boards.Where(board => !board.IsBingo))
        {
            if (b.TryCheck(draw) && b.HasBingo())
            {
                winningBoard = b.Clone();
                lastDrawWhenWinningBoard = draw;
            }
        };

        if (boards.All(b => b.IsBingo))
        {
            break;
        }
    }

    var score = winningBoard?.GetScore(lastDrawWhenWinningBoard);

    Console.WriteLine($"Result: {score}");
}

Console.WriteLine("First or second half ? (1 or 2)");
switch (Console.ReadLine() ?? string.Empty)
{
    case "2": Second(); break;
    default: First(); break;
}


class Board
{
    private static int cpt = 1;

    public Cell[][] Cells { get; set; } = new Cell[5][];
    public int Id { get; }

    public bool IsBingo = false;

    private Board()
    {
        for (int i = 0; i < 5; i++)
        {
            Cells[i] = new Cell[5];
        }
    }

    public Board(string[] lines)
    {
        Id = cpt++;
        for (int i = 0; i < lines.Length; i++)
        {
            Cells[i] = new Cell[5];
            var values = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < values.Length; j++)
            {
                Cells[i][j] = new Cell { Value = int.Parse(values[j]), IsChecked = false };
            }
        }
    }

    public bool TryCheck(int value)
    {
        foreach (var line in Cells)
        {
            foreach (var cell in line.Where(c => !c.IsChecked))
            {
                if (cell.Value == value)
                {
                    cell.IsChecked = true;
                    return true;
                }
            }
        }

        return false;
    }

    public bool HasBingo()
    {
        if (IsBingo)
        {
            return true;
        }

        for (var i = 0; i < 5; i++)
        {
            if (Enumerable.Range(0, 5).Select(j => Cells[i][j].IsChecked).All(check => check))
            {
                // BINGO horizontal
                IsBingo = true;
                return true;
            }

            if (Enumerable.Range(0, 5).Select(j => Cells[j][i].IsChecked).All(check => check))
            {
                // Bingo horizontal
                IsBingo = true;
                return true;
            }
        }

        return false;
    }

    public int GetScore(int lastDrawnNumber)
    {
        var sum = Cells.SelectMany(cells => cells.Where(c => !c.IsChecked).Select(c => c.Value))
                       .Sum();

        return sum * lastDrawnNumber;
    }

    public Board Clone()
    {
        var b = new Board();

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                b.Cells[i][j] = Cells[i][j];
            }
        }

        return b;
    }
}

class Cell
{
    public int Value { get; set; }
    public bool IsChecked { get; set; }
}
