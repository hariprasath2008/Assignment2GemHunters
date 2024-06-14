using System.Numerics;

public class Board
{
    public Cell[,] Grid { get; set; }

    public Board()
    {
        Grid = new Cell[6, 6];
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Grid[i, j] = new Cell();
            }
        }
        PlaceObstacles();
        PlaceGems();
        Grid[0, 0].Occupant = "P1";
        Grid[5, 5].Occupant = "P2";
    }

    private void PlaceObstacles()
    {
        Random rnd = new Random();
        for (int i = 0; i < 5; i++)
        {
            while (true)
            {
                int x = rnd.Next(6);
                int y = rnd.Next(6);
                if (Grid[x, y].Occupant == "-")
                {
                    Grid[x, y].Occupant = "O";
                    break;
                }
            }
        }
    }

    private void PlaceGems()
    {
        Random rnd = new Random();
        for (int i = 0; i < 8; i++)
        {
            while (true)
            {
                int x = rnd.Next(6);
                int y = rnd.Next(6);
                if (Grid[x, y].Occupant == "-")
                {
                    Grid[x, y].Occupant = "G";
                    break;
                }
            }
        }
    }

    public void Display()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Console.Write(Grid[i, j].Occupant + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public bool IsValidMove(Player player, char direction)
    {
        int newX = player.Position.X;
        int newY = player.Position.Y;

        switch (direction)
        {
            case 'U':
                newX -= 1;
                break;
            case 'D':
                newX += 1;
                break;
            case 'L':
                newY -= 1;
                break;
            case 'R':
                newY += 1;
                break;
        }

        return newX >= 0 && newX < 6 && newY >= 0 && newY < 6 && Grid[newX, newY].Occupant != "O";
    }

    public void CollectGem(Player player)
    {
        if (Grid[player.Position.X, player.Position.Y].Occupant == "G")
        {
            player.GemCount++;
            Grid[player.Position.X, player.Position.Y].Occupant = "-";
        }
    }
}