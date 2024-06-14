class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("!!Welcome to the Gem Hunters Board Game!!");
        Console.WriteLine("Enter Player 1(P1) Name:");
        string player1Name=Console.ReadLine();
        Console.WriteLine("Enter Player 2(P2) Name:");
        string player2Name=Console.ReadLine();
        Gemgame gemgame = new Gemgame(player1Name,player2Name);
        gemgame.Start();
    }
}