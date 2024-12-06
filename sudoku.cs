using System;

public class SudokuValidator
{
    public static bool IsValidSudoku(int[][] board)
    {
        int N = board.Length;

        // Check if N is a perfect square
        int sqrtN = (int)Math.Sqrt(N);
        if (sqrtN * sqrtN != N)
        {
            return false;
        }

        // Check rows, columns, and subgrids
        for (int i = 0; i < N; i++)
        {
            if (!IsValidGroup(board[i])) ///row wise checking   
            {
                return false;
            }

            int[] column = new int[N];
            for (int j = 0; j < N; j++)
            {
                syste
                column[j] = board[j][i];
            }
            if (!IsValidGroup(column)) // column wise checking
            {
                return false;
            }
        }

        // Check subgrids
        for (int rowStart = 0; rowStart < N; rowStart += sqrtN)
        {
            for (int colStart = 0; colStart < N; colStart += sqrtN)
            {
                if (!IsValidSubgrid(board, rowStart, colStart, sqrtN))
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static bool IsValidGroup(int[] group)
    {
        int N = group.Length;
        bool[] seen = new bool[N + 1]; // To track seen numbers
        foreach (int num in group)
        {
            if (num < 1 || num > N || seen[num])
            {
                return false;
            }
            seen[num] = true;
        }
        return true;
    }

    private static bool IsValidSubgrid(int[][] board, int rowStart, int colStart, int size)
    {
        int N = size * size;
        bool[] seen = new bool[N + 1];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                int num = board[rowStart + i][colStart + j];
                if (num < 1 || num > N || seen[num])
                {
                    return false;
                }
                seen[num] = true;
            }
        }
        return true;
    }

    public static void Main(string[] args)
    {
        int[][] goodSudoku1 = {
            new int[] {7, 8, 4, 1, 5, 9, 3, 2, 6},
            new int[] {5, 3, 9, 6, 7, 2, 8, 4, 1},
            new int[] {6, 1, 2, 4, 3, 8, 7, 5, 9},
            new int[] {9, 2, 8, 7, 1, 5, 4, 6, 3},
            new int[] {3, 5, 7, 8, 4, 6, 1, 9, 2},
            new int[] {4, 6, 1, 9, 2, 3, 5, 8, 7},
            new int[] {8, 7, 6, 3, 9, 4, 2, 1, 5},
            new int[] {2, 4, 3, 5, 6, 1, 9, 7, 8},
            new int[] {1, 9, 5, 2, 8, 7, 6, 3, 4}
        };

        Console.WriteLine("Is valid Sudoku? " + IsValidSudoku(goodSudoku1));
    }
}
