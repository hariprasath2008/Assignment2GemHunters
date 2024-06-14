public class Player
{
    public string Name { get; set; }
    public Position Position { get; set; }
    public int GemCount { get; set; }

    public Player(string name, Position position)
    {
        Name = name;
        Position = position;
        GemCount = 0;
    }

    public void Move(char direction)
    {
        switch (direction)
        {
            case 'U':
                Position.X -= 1;
                break;
            case 'D':
                Position.X += 1;
                break;
            case 'L':
                Position.Y -= 1;
                break;
            case 'R':
                Position.Y += 1;
                break;
        }
    }
}