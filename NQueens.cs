namespace algorithm;

public static class NQueens
{

    public static IEnumerable<int[]> Queens(int n)
    {
        if (n <= 0)
            yield break;

        int[] position = new int[n];

        if (n == 1)
        {
            yield return position;
            yield break;
        }

        while (true)
        {
            for (int file = 1; file < n;)
            {
                int rank = position[file];

                // check if queen in the same row || queen in the top-left to bottom-right || top-right to bottom-left
                if (position.Take(file).Select((r, c) => r == rank || rank - r == file - c ||  rank - r == c - file).Any(x => x))
                {
                    while (position[file] >= n - 1) //has been placed in the last row or beyond
                    {
                        position[file] = 0; //reset to the first row

                        if (--file < 0) // and there are no more solutions to find
                            yield break;
                    }

                    position[file] += 1; //different positions for the queen
                }
                else // next queen (current queen in the valid position)
                    file += 1;
            }

            yield return position.ToArray(); // return solution

            for (int i = n - 1; i >= 0; --i)
                if (++position[i] >= n)
                    position[i] = 0; // reset to the first row
                else
                    break; //valid position
        }
    }
}