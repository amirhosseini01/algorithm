using algorithm;

var result = NQueens.Queens(8)
  .Select(solution => string.Join(" ", solution.Select((r, f) => $"{(char)('A' + f)}{r + 1}")));

Console.Write(string.Join(Environment.NewLine, result));