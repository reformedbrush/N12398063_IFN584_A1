using System;

public class Board
{
    private string[,] board;

    public Board()
    {
        board = new string[10,10];

        for(int row=0; row<10; row++)
        {
            for(int col=0; col<10; col++)
            {
                board[row,col]=" ";
            }
        }
    }
    public void Display()
    {
        Console.Write("  ");

        for(int col = 1; col <= 10; col++)
        {
            Console.Write($" {col,3}");
        }

        Console.WriteLine();

        Console.Write("   +");

        for (int col=0; col<10; col++)
        {
            Console.Write("---+");
        }
        Console.WriteLine();

        for(int row = 0; row < 10; row++)
        {
            Console.Write($"{row + 1,2} |");

            for(int col =0; col<10; col++)
            {
               Console.Write($" {board[row,col]} |"); 
            }

            Console.WriteLine();

            Console.Write("   +");
            for(int col=0; col<10; col++)
            {
                Console.Write("---+");
            }

            Console.WriteLine();
            
        }
    }

    public bool PlaceStone(int row, int col, string stone)
    {
        if (row<1 || row>10 || col <1 || col > 10)
        {
            return false;
        }

        if(board[row -1, col - 1]!=" ")
        {
            return false;
        }
        board[row -1, col-1]=stone;

        return true;
    }
    
}