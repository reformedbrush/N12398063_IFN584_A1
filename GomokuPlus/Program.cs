using System;
using System.Net;

Console.WriteLine("1. Human vs Human");
Console.WriteLine("2. Human vs Computer");
Console.WriteLine("Choose game mode: ");
string gameMode=Console.ReadLine();

if(gameMode!= "1" && gameMode != "2")
{
    Console.WriteLine("Invalid game mode.");
    return;
}

Board gameBoard = new Board();

string currentPlayer = "X";
int turnCount =0;
ComputerPlayer computer= new ComputerPlayer();

int playerXHeavyStones=2;
int playerOHeavyStones=2;

int playerXEraser = 2;
int playerOEraser = 2;

while (true)
{
    Console.WriteLine();
    Console.WriteLine($"Player {currentPlayer}'s turn");

    Console.Write("Enter Command (Q to quit, HELP for Instructions): ");
    string command = Console.ReadLine();


    if(command == "HELP" || command == "help")
    {
        Console.WriteLine("O = Normal Stone");
        Console.WriteLine("H = Heavy Stone");
        Console.WriteLine("E = Eraser");
        Console.WriteLine("Q = Quit");
        Console.WriteLine("Commands use the format O[row]:[column]");
        Console.WriteLine("Example: O5:5");
        continue;
    }

    if(command =="S" || command == "s")
    {
        gameBoard.SaveGame("savegame.txt",currentPlayer,gameMode,turnCount,
        playerXHeavyStones,playerOHeavyStones,playerXEraser,playerOEraser);

        Console.WriteLine("GameSaved.");
        continue;
    }

    if(command =="L" || command == "l")
    {
        try
        {
            gameBoard.LoadGame("savegame.txt",out currentPlayer,out gameMode,out turnCount,
            out playerXHeavyStones,out playerOHeavyStones,out playerXEraser,out playerOEraser);

            Console.WriteLine("Game Loaded.");
            gameBoard.Display();
        }

        catch
        {
            Console.WriteLine("Unable to load game.");
        }
        continue;
    }

    string stoneChoice = command.Substring(0,1);


    if (stoneChoice == "Q" || stoneChoice == "q")
    {
        break;
    }

    if(stoneChoice != "O" && stoneChoice !="H" && stoneChoice != "E")
    {
        Console.WriteLine("Invalid Command.");
        continue;
    }

    int row;
    int col;

    int colon = command.IndexOf(':');
    if (colon == -1)
    {
        Console.WriteLine("Invalid Command");
        continue;
    }

    try{

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
            placed=gameBoard.EraseStone(row,col,currentPlayer);

            if (placed)
            {
                playerXEraser--;
            }
        }

        else if(currentPlayer=="O" && playerOEraser > 0)
        {
            placed=gameBoard.EraseStone(row,col,currentPlayer);

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
        turnCount++;
        if (stoneChoice == "E")
        {
            Console.WriteLine("Stone Erased.");
        }
        else
        {
            Console.WriteLine("Stone Placed");

            if (gameBoard.CheckWin(row, col, currentPlayer))
            {
                gameBoard.Display();
                Console.WriteLine($"Player {currentPlayer} WINS!");
                break;
            }
        }

      if (currentPlayer == "X")
        {
            currentPlayer = "O";

            if (gameMode == "2")
            {
                int[] computerMove = computer.MakeMove(gameBoard);

                if (computerMove[0] == -1)
                {
                    Console.WriteLine("The board is full.");
                    break;
                }

                Console.WriteLine(
                    $"Computer placed a stone at {computerMove[0]}:{computerMove[1]}"
                );

                gameBoard.Display();

                if (gameBoard.CheckWin(
                    computerMove[0],
                    computerMove[1],
                    "O"))
                {
                    Console.WriteLine("Computer WINS!");
                    break;
                }

                currentPlayer = "X";
            }
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