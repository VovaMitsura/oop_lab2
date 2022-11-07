using lab2.games;

namespace lab2.accounts;

public abstract class Account
{
    public string UserName { get; }
    public short CurrentRating { get; protected set; }
    protected readonly List<GameStat> GameStats;

    protected const short MaxRate = 32767;

    protected Account(List<GameStat> gameStats, string userName, short currentRating)
    {
        GameStats = gameStats;
        UserName = userName;
        CurrentRating = (short)(IsValidRate(currentRating) ? currentRating : 1);
    }

    private static Boolean IsValidRate(short rating)
    {
        return rating is > 0 and < MaxRate;
    }

    public abstract void WinGame(Game game);
    public abstract void LoseGame(Game game);

    public virtual string GetStats()
    {
        var report = new System.Text.StringBuilder();

        report.AppendLine($"User:\t{this.UserName}\nGame Number\tType\t\tWinner\t\tLoser\t\tBit Rate");


        for (var i = 0; i < GameStats.Count; i++)
        {
            report.AppendLine($"{i + 1}\t\t{GameStats[i].TypeOfGame}\t{GameStats[i].WinnerOpponent}" +
                              $"\t\t{GameStats[i].LoserOpponent}\t\t" +
                              $"{GameStats[i].GameRate}");
        }

        return report.ToString();
    }
}