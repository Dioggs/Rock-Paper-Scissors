namespace RPS;

public class Player : IPlayer
{
    public string Name;
    public int Wins;
    public int Losses;

    public Player(string name)
    {
        Name = name;
    }
    
    public string? GetInput()
    {
        var input = ReadLine()!;

        if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)) return null;

        if (input != "rock" && input != "paper" && input != "scissors") return null;

        return input;
    }
}