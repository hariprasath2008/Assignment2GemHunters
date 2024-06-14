using System.Numerics;

public class Gemgame
{
    public Board Board { get; set; }
    public Player Player1 { get; set; }
    public Player Player2 { get; set; }
    public Player CurrentTurn { get; set; }
    public int TotalTurns { get; set; }

    public Gemgame()
    {
        Board = new Board();
        Player1 = new Player("P1", new Position(0, 0));
        Player2 = new Player("P2", new Position(5, 5));
        CurrentTurn = Player1;
        TotalTurns = 0;
    }

    public void Start()
    {
        while (!IsGameOver())
        {
            Board.Display();
            Console.WriteLine(CurrentTurn.Name+"'s turn. Enter the move from(\"U, D, L, R\"):");
            char move = Console.ReadLine().ToUpper()[0];

            if (Board.IsValidMove(CurrentTurn, move))
            {
                MovePlayer(CurrentTurn, move);
                Board.CollectGem(CurrentTurn);
                TotalTurns++;
                SwitchTurn();
            }
            else
            {
                Console.WriteLine("Not a valid move.Retry!");
            }
        }

        Board.Display();
        AnnounceWinner();
    }

    private void MovePlayer(Player player, char direction)
    {
        Board.Grid[player.Position.X, player.Position.Y].Occupant = "-";
        player.Move(direction);
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
        Console.WriteLine($"The Gane is Over! {Player1.Name} Gems: {Player1.GemCount}, {Player2.Name} Gems: {Player2.GemCount}");
        if (Player1.GemCount > Player2.GemCount)
        {
            Console.WriteLine(Player1.Name+" won!");
        }
        else if (Player2.GemCount > Player1.GemCount)
        {
            Console.WriteLine(Player1.Name+" won!");
        }
        else
        {
            Console.WriteLine("It is a draw!");
        }
    }
}