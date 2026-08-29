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

    Console.WriteLine("1. Normal Stone");
    Console.WriteLine("2. Heavy Stone");
    Console.WriteLine("3. Eraser");
    Console.Write("Choose stone type (Q to quit): ");
    string stoneChoice = Console.ReadLine();

    if (stoneChoice == "Q" || stoneChoice == "q")
    {
        break;
    }

    Console.Write("Enter Row: ");
    int row = int.Parse(Console.ReadLine());

    Console.Write("Enter Column: ");
    int col = int.Parse(Console.ReadLine());

    bool placed = false;

    if (stoneChoice == "1")
    {
        placed = gameBoard.PlaceStone(row, col, currentPlayer);
    }
    else if (stoneChoice == "2")
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
    
    else if (stoneChoice == "3")
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