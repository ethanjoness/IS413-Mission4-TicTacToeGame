using System;

public class Support
{
    // Prints the 3x3 board
    public void PrintBoard(char[,] board)
    {
        Console.Clear(); // optional, remove if you don't want the screen to clear

        Console.WriteLine("Current board:");
        Console.WriteLine();

        for (int row = 0; row < 3; row++)
        {
            Console.Write(" "); // left padding

            for (int col = 0; col < 3; col++)
            {
                char value = board[row, col];
                if (value == ' ')
                {
                    value = ' '; // keep empty spaces as blanks
                }

                Console.Write(value);

                if (col < 2)
                {
                    Console.Write(" | ");
                }
            }

            Console.WriteLine();

            if (row < 2)
            {
                Console.WriteLine("---+---+---");
            }
        }

        Console.WriteLine();
    }

    // Returns 'X', 'O', 'T' (tie), or ' ' (no result yet)
    public char GameResult(char[,] board)
    {
        // 1. Check rows
        for (int row = 0; row < 3; row++)
        {
            if (board[row, 0] != ' ' &&
                board[row, 0] == board[row, 1] &&
                board[row, 1] == board[row, 2])
            {
                return board[row, 0]; // 'X' or 'O'
            }
        }

        // 2. Check columns
        for (int col = 0; col < 3; col++)
        {
            if (board[0, col] != ' ' &&
                board[0, col] == board[1, col] &&
                board[1, col] == board[2, col])
            {
                return board[0, col]; // 'X' or 'O'
            }
        }

        // 3. Check diagonals
        if (board[1, 1] != ' ')
        {
            // main diagonal (0,0) (1,1) (2,2)
            if (board[0, 0] == board[1, 1] &&
                board[1, 1] == board[2, 2])
            {
                return board[1, 1];
            }

            // anti-diagonal (0,2) (1,1) (2,0)
            if (board[0, 2] == board[1, 1] &&
                board[1, 1] == board[2, 0])
            {
                return board[1, 1];
            }
        }

        // 4. Check for tie (no empty spaces)
        bool hasEmpty = false;
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board[row, col] == ' ')
                {
                    hasEmpty = true;
                    break;
                }
            }
            if (hasEmpty)
            {
                break;
            }
        }

        if (!hasEmpty)
        {
            return 'T'; // tie
        }

        // No winner and spaces left → game continues
        return ' ';
    }
}
