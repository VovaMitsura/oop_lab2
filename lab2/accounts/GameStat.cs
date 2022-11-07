namespace lab2.accounts;

public class GameStat
{
    public readonly string TypeOfGame;
    public readonly string WinnerOpponent;
    public readonly string LoserOpponent;
    public short GameRate { get; }

    public GameStat(string typeOfGame, string winnerOpponent, string loserOpponent, short gameRate)
    {
        TypeOfGame = typeOfGame;
        WinnerOpponent = winnerOpponent;
        LoserOpponent = loserOpponent;
        GameRate = gameRate;
    }
}