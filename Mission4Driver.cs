using System;

class Program
{
    static void Main(string[] args)
    {
        // Welcome the user
        Console.WriteLine("Welcome to TicTacToe!");
        Console.WriteLine("Player 1 is X, Player 2 is O.");
        Console.WriteLine("Enter a row and column (1-3).\n");

        // Create the game board array
        char[,] gameBoard = new char[3, 3];
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                gameBoard[row, col] = ' ';
            }
        }


        // Create an instance of the supporting class
        Support game = new Support();

        // Game loop
        char currentPlayer = 'X';
        bool gameOver = false;

        while (!gameOver)
        {
            // print gameboard
            game.PrintBoard(gameBoard);
            
            string playerName = (currentPlayer == 'X') ? "Player 1" : "Player 2";
            
            // Get a valid move
            bool validMove = false;
            int row = 0;
            int col = 0;

            while (!validMove)
            {
                Console.Write($"{playerName}, enter your row (1-3): ");
                bool validRow = int.TryParse(Console.ReadLine(), out row) &&
                                row >= 1 && row <= 3;

                Console.Write($"{playerName}, enter your column (1-3): ");
                bool validCol = int.TryParse(Console.ReadLine(), out col) &&
                                col >= 1 && col <= 3;

                if (!validRow || !validCol)
                {
                    Console.WriteLine("Invalid input. Please enter numbers between 1 and 3.\n");
                }
                else if (gameBoard[row - 1, col - 1] != ' ')
                {
                    Console.WriteLine("That position is already taken. Try again.\n");
                }
                else
                {
                    row -= 1;
                    col -= 1;
                    validMove = true;
                }
            }
            
            // Place the move
            gameBoard[row, col] = currentPlayer;
            
            // Check for winner
            char result = game.GameResult(gameBoard);

            if (result == 'X' || result == 'O')
            {
                game.PrintBoard(gameBoard);
                Console.WriteLine($"{playerName} wins!");
                gameOver = true;
            }
            else if (result == 'T')
            {
                game.PrintBoard(gameBoard);
                Console.WriteLine("It's a tie!");
                gameOver = true;
            }
            else
            {
                // Switch players
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }

        }
        // End of game message
        Console.WriteLine("\nThanks for playing!");
    }

    // Helper method(s) for input handling (optional)
    
}