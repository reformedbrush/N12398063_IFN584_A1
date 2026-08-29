public class ComputerPlayer
{
    public int[] MakeMove(Board gameBoard)
    {
        for (int row = 1; row <= 10; row++)
        {
            for (int col = 1; col <= 10; col++)
            {
                if (gameBoard.IsEmpty(row, col))
                {
                    gameBoard.PlaceStone(row, col, "O");

                    return new int[] { row, col };
                }
            }
        }

        return new int[] { -1, -1 };
    }
}