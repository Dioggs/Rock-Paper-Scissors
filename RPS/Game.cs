namespace RPS;

public class Game
{
    private readonly IPlayer _player;
    private readonly IPlayer _computer;

    private readonly Dictionary<string, string> _loseValues = new()
    {
        {"rock", "scissors"},
        {"scissors", "paper"},
        {"paper", "rock"}
    };
    
    public Game(IPlayer player, IPlayer computer)
    {
        _player = player;
        _computer = computer;
    }
    
    public void Play()
    {
        int numOfGames;
        PrintIntroduction();
        
        Write("\nPress any key to continue...");
        ReadKey();
        Clear();

        while (true)
        {
            Write("How many games would you like to play?: ");
            bool isValidConversion = int.TryParse(ReadLine()!, out numOfGames);

            if (isValidConversion && numOfGames < 11) break;
            
            Clear();
            WriteLine("Invalid Value was given!");
            WriteLine("Please give a numeric value");
            WriteLine("The maximum number of games you can play is 10\n");
        }
        
        for(int i = 0; i < numOfGames; i++)
        {
            Clear();
            string? computerChoice = _computer.GetInput();
            string? playerChoice;
            
            do
            {
                Write("What is your choice?: ");
                playerChoice = _player.GetInput();
            } while (playerChoice == null);
            
            CheckForWinner(playerChoice!, computerChoice!);
            
        }
        
        PrintResults((Player)_player, (Computer)_computer);
    }

    private void PrintIntroduction()
    {
        WriteLine("\n______           _       ______                             _____      _                        \n| ___ \\         | |      | ___ \\                           /  ___|    (_)                       \n| |_/ /___   ___| | __   | |_/ /_ _ _ __   ___ _ __ ___    \\ `--.  ___ _ ___ ___  ___  _ __ ___ \n|    // _ \\ / __| |/ /   |  __/ _` | '_ \\ / _ \\ '__/ __|    `--. \\/ __| / __/ __|/ _ \\| '__/ __|\n| |\\ \\ (_) | (__|   < _  | | | (_| | |_) |  __/ |  \\__ \\_  /\\__/ / (__| \\__ \\__ \\ (_) | |  \\__ \\\n\\_| \\_\\___/ \\___|_|\\_( ) \\_|  \\__,_| .__/ \\___|_|  |___( ) \\____/ \\___|_|___/___/\\___/|_|  |___/\n                     |/            | |                 |/                                       \n                                   |_|                                                          \n");
        WriteLine("Welcome to the Rock, Papers, Scissors game!");
        WriteLine("You'll be fighting against the computer, so good luck!");
    }

    private void CheckForWinner(string playerChoice, string computerChoice)
    {
        if (_loseValues[computerChoice] == playerChoice)
        {
            var player = (Player)_player;
            player.Wins++;
            var computer = (Computer)_computer;
            computer.Losses++;
            PrintWinMessage(playerChoice, computerChoice);
        }
        else if (_loseValues[playerChoice] == computerChoice)
        {
            var player = (Player)_player;
            player.Losses++;
            var computer = (Computer)_computer;
            computer.Wins++;
            PrintLoseMessage(playerChoice, computerChoice);
        }
        else
        {
            PrintTieMessage(playerChoice, computerChoice);
        }
    }

    private void PrintWinMessage(string playerChoice, string computerChoice)
    {
        WriteLine("Congratulations! you've Won a point!");
        WriteLine($"The computer chose {playerChoice} and you chose {computerChoice}");
        ReadKey();
    }
    
    private void PrintLoseMessage(string playerChoice, string computerChoice)
    {
        WriteLine("Oh No! you've Lost a point!");
        WriteLine($"The computer chose {playerChoice} and you chose {computerChoice}");
        ReadKey();
    }

    private void PrintTieMessage(string playerChoice, string computerChoice)
    {
        WriteLine("Oh No! a tie has occured");
        WriteLine($"The computer chose {playerChoice} and you chose {computerChoice}");
        ReadKey();
    }

    private void PrintResults(Player player, Computer computer)
    {
        Clear();
        WriteLine($"You have {player.Wins} wins and {player.Losses} losses");
        WriteLine($"The computer has {computer.Wins} wins and {computer.Losses} losses");
        ReadKey();
    }
}