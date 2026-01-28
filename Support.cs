namespace Mission4;

public class Support
{
    // What do you need to store here as class-level variables?
    // - The game board state?
    // - Whose turn is it?
    
    public void PrintBoard(int[] move)
    {
        // 1. Update your internal board with the new move
        // 2. Figure out if this is X or O
        // 3. Print the entire board
    }


    public string GameResult(int[] board)
    {
        if (board[0] == board[1] && board[1] == board[2])
        {
            Console.WriteLine($"Player {board[0]} Won!");
        }
    }
}