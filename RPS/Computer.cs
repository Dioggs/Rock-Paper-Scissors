namespace RPS;

public class Computer : IPlayer
{
    private readonly Dictionary<int, string> _computerValues = new()
    {
        {1, "rock"},
        {2, "paper"},
        {3, "scissors"}
    };

    private readonly Random _rnd = new();
    public int Wins;
    public int Losses;
    
    public string? GetInput()
    {
        int randomNumber = _rnd.Next(1, 4);
        string computerChoice = _computerValues[randomNumber];
        return computerChoice;
    }
}