Console.WriteLine("Input file ?");
var file = Console.ReadLine();

if (!File.Exists(file))
{
    Console.WriteLine("File not found");
    return;
}

var lines = File.ReadAllLines(file);
var totalCount = lines.Length;
var lineItemsCount = lines[0].ToCharArray().Length;
var values = new int[lineItemsCount];
var mid = totalCount / 2M;

foreach(var vals in lines)
{
    for (int j = 0; j < vals.Length; j++)
    {
        char val = vals[j];
        if (val == '1') { values[j]++; }
    }
}

string binary = new string(values.Select(v => v > mid ? '1' : '0').ToArray());
string invertedBinary = new string(binary.ToArray().Select(b => b == '1' ? '0' : '1').ToArray());

int gamma = Convert.ToInt32(binary,2);
int epsilon = Convert.ToInt32(invertedBinary, 2);

Console.WriteLine($"Result: {gamma * epsilon}");
