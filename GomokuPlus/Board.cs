using System;
using System.Data;

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

    public bool IsPlayerStone(int row,int col, string player)
    {
        if (player == "X")
        {
            return board[row,col]=="X" || board[row,col]=="@";
        }

        else
        {
            return board[row,col]=="O" || board[row,col]=="#";
        }
    }
    
    public bool CheckWin(int row, int col, string player)
{
    int boardRow = row - 1;
    int boardCol = col - 1;

    int count = 1;

    // horizontal check
    for (int c = boardCol - 1; c >= 0; c--)
    {
        if (IsPlayerStone(boardRow, c, player))
        {
            count++;
        }
        else
        {
            break;
        }
    }

    for (int c = boardCol + 1; c < 10; c++)
    {
        if (IsPlayerStone(boardRow, c, player))
        {
            count++;
        }
        else
        {
            break;
        }
    }

    if (count >= 5)
    {
        return true;
    }

    count = 1;

    // vertical check
    for (int r = boardRow - 1; r >= 0; r--)
    {
        if (IsPlayerStone(r, boardCol, player))
        {
            count++;
        }
        else
        {
            break;
        }
    }

    for (int r = boardRow + 1; r < 10; r++)
    {
        if (IsPlayerStone(r, boardCol, player))
        {
            count++;
        }
        else
        {
            break;
        }
    }

    if (count >= 5)
    {
        return true;
    }

    count = 1;

    // diagonal check \

    for (int r = boardRow - 1, c = boardCol - 1;
         r >= 0 && c >= 0;
         r--, c--)
    {
        if (IsPlayerStone(r, c, player))
        {
            count++;
        }
        else
        {
            break;
        }
    }

    for (int r = boardRow + 1, c = boardCol + 1;
         r < 10 && c < 10;
         r++, c++)
    {
        if (IsPlayerStone(r, c, player))
        {
            count++;
        }
        else
        {
            break;
        }
    }

    if (count >= 5)
    {
        return true;
    }

    // diagonal check #2 /

    count = 1;

    for (int r = boardRow + 1, c = boardCol - 1;
         r < 10 && c >= 0;
         r++, c--)
    {
        if (IsPlayerStone(r, c, player))
        {
            count++;
        }
        else
        {
            break;
        }
    }

    for (int r = boardRow - 1, c = boardCol + 1;
         r >= 0 && c < 10;
         r--, c++)
    {
        if (IsPlayerStone(r, c, player))
        {
            count++;
        }
        else
        {
            break;
        }
    }

    if (count >= 5)
    {
        return true;
    }

    return false;
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

    public bool PlaceHeavyStone(int row,int col, string player)
    {
        int boardRow = row - 1;
        int boardCol = col - 1;

       if(boardRow<0 || boardRow>=10 || boardCol<0 || boardCol >= 10)
        {
            return false;
        }

        if(board[boardRow,boardCol]!= " ")
        {
            return false;
        }
        if (player == "X")
        {
            board[boardRow,boardCol]="@";
        }
        else
        {
            board[boardRow,boardCol]="#";
        }

        return true;
    }

    public bool EraseStone(int row,int col)
    {
        int boardRow = row-1;
        int boardCol = col-1;

        if(boardRow<0 || boardRow>=10 || boardCol<0 || boardCol >= 10)
        {
            return false;
        }

        if(board[boardRow,boardCol]!="X"&& board[boardRow, boardCol] != "O")
        {
            return false;
        }

        board[boardRow,boardCol]=" ";
        return true;
    }
    
}