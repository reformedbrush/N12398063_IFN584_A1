Board gameBoard= new Board();

String currentPlayer = "X";

//gameBoard.PlaceStone(5, 5, "X");

while (true)
{

    Console.WriteLine($"Player {currentPlayer}'s turn");
    Console.Write("Enter Row (or Q to Quit): ");
    string input = Console.ReadLine();

    if(input == "Q" || input == "q")
    {
        break;
    }
    
    int row=int.Parse(input);

    Console.Write("Enter Column: ");
    int col= int.Parse(Console.ReadLine());

    bool placed = gameBoard.PlaceStone(row, col, currentPlayer);

    if (placed)
    {
        Console.WriteLine("Stone Placed");
        if (gameBoard.CheckWin(row, col, currentPlayer))
        {
            gameBoard.Display();
            Console.WriteLine($"Player {currentPlayer} WINS !");
            break;
        }
            if (currentPlayer == "X")
            {
                currentPlayer="0";
            }
            else
            {
                currentPlayer="X";
            }
    }
    else
    {
     Console.WriteLine("Invalid Move");
    }
gameBoard.Display();
}