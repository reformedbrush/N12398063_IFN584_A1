using System;

Board gameBoard = new Board();

string currentPlayer = "X";

int playerXHeavyStones=2;
int playerOHeavyStones=2;

int playerXEraser = 2;
int playerOEraser = 2;

while (true)
{
    Console.WriteLine();
    Console.WriteLine($"Player {currentPlayer}'s turn");

    Console.Write("Enter Command (Q to quit): ");
    string command = Console.ReadLine();

    string stoneChoice = command.Substring(0,1);

    if (stoneChoice == "Q" || stoneChoice == "q")
    {
        break;
    }

    if(stoneChoice != "o"&& stoneChoice !="H" && stoneChoice != "E")
    {
        Console.WriteLine("Invalid Command.");
        continue;
    }

    int row;
    int col;

    try{
        int colon = command.IndexOf(':');

         row = int.Parse(command.Substring(1,colon-1));
         col = int.Parse(command.Substring(colon+1));
    }
    catch
    {
        Console.WriteLine("Invalid Command");
        continue;
    }

    bool placed = false;

    if (stoneChoice == "O")
    {
        placed = gameBoard.PlaceStone(row, col, currentPlayer);
    }
    else if (stoneChoice == "H")
    {
       if(currentPlayer=="X" && playerXHeavyStones > 0)
        {
            placed=gameBoard.PlaceHeavyStone(row,col,currentPlayer);
            if (placed)
            {
                playerXHeavyStones--;
            }
        }
        else if(currentPlayer=="O" && playerOHeavyStones > 0)
        {
            placed=gameBoard.PlaceHeavyStone(row,col,currentPlayer);

            if (placed)
            {
                playerOHeavyStones--;
            }
        }
        else
        {
            Console.WriteLine("No Heavy Stones Remaining.");
        }
    }
    
    else if (stoneChoice == "E")
    {
        if(currentPlayer=="X" && playerXEraser>0)
        {
            placed=gameBoard.EraseStone(row,col);

            if (placed)
            {
                playerXEraser--;
            }
        }

        else if(currentPlayer=="O" && playerOEraser > 0)
        {
            placed=gameBoard.EraseStone(row,col);

            if (placed)
            {
                playerOEraser--;
            }
        }

        else
        {
            Console.WriteLine("No Erasers Remaining.");
        }
    }
    else
    {
        Console.WriteLine("Invalid stone choice.");
        continue;
    }

    if (placed)
    {
        Console.WriteLine("Stone Placed");

        if (gameBoard.CheckWin(row, col, currentPlayer))
        {
            gameBoard.Display();
            Console.WriteLine($"Player {currentPlayer} WINS!");
            break;
        }

        if (currentPlayer == "X")
        {
            currentPlayer = "O";
        }
        else
        {
            currentPlayer = "X";
        }
    }
    else
    {
        Console.WriteLine("Invalid Move");
    }

    gameBoard.Display();
}