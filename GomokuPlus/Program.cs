Board gameBoard= new Board();

//gameBoard.PlaceStone(5, 5, "X");

while (true)
{
    Console.Write("Enter Row: ");
int row= int.Parse(Console.ReadLine());

Console.Write("Enter Column: ");
int col= int.Parse(Console.ReadLine());

bool placed = gameBoard.PlaceStone(row, col, "x");

if (placed)
{
    Console.WriteLine("Stone Placed");
}
else
{
    Console.WriteLine("Invalid Move");
}
gameBoard.Display();
}