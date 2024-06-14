using System.Numerics;

public class Gemgame
{
    public Board Board { get; set; }
    public Player Player1 { get; set; }
    public Player Player2 { get; set; }
    public Player CurrentTurn { get; set; }
    public int TotalTurns { get; set; }

    public Gemgame(string player1Name,string player2Name)
    {
        Board = new Board();
        Player1 = new Player("P1", new Position(0, 0),player1Name);
        Player2 = new Player("P2", new Position(5, 5), player2Name);
        CurrentTurn = Player1;
        TotalTurns = 0;
    }

    public void Start()
    {
        while (!IsGameOver())
        {
            Board.Display(Player1,Player2,TotalTurns);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(CurrentTurn.PlayerName+"'s turn. Enter the move from(\"U, D, L, R\"):");
            char move = Console.ReadLine().ToUpper()[0];

            if (Board.IsValidMove(CurrentTurn, move))
            {
                MovePlayer(CurrentTurn, move);
               
                TotalTurns++;
                SwitchTurn();
            }
            else
            {
                Console.WriteLine("Not a valid move.Retry!");
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }
        }

        AnnounceWinner();
    }

    private void MovePlayer(Player player, char direction)
    {
        Board.Grid[player.Position.X, player.Position.Y].Occupant = "-";
        player.Move(direction);
        Board.CollectGem(CurrentTurn);
        Board.Grid[player.Position.X, player.Position.Y].Occupant = player.Name;
    }

    private void SwitchTurn()
    {
        CurrentTurn = CurrentTurn == Player1 ? Player2 : Player1;
    }

    private bool IsGameOver()
    {
        if (TotalTurns >= 30)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void AnnounceWinner()
    {
        Console.WriteLine($"The Game is Over! {Player1.PlayerName} Gems: {Player1.GemCount}, {Player2.PlayerName} Gems: {Player2.GemCount}");
        if (Player1.GemCount > Player2.GemCount)
        {
            Console.WriteLine(Player1.PlayerName+" won!");
        }
        else if (Player2.GemCount > Player1.GemCount)
        {
            Console.WriteLine(Player2.PlayerName + " won!");
        }
        else
        {
            Console.WriteLine("It is a draw!");
        }
    }
}