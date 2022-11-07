using lab2.games;

namespace lab2.accounts;

public class PremiumAccount : Account
{
    private readonly double _bonusForWin;
    private const double DefaultBonusForWin = 1.5;

    public PremiumAccount(List<GameStat> gameStats, string userName, short currentRating, double bonusForWin) : base(
        gameStats, userName,
        currentRating)
    {
        this._bonusForWin = bonusForWin;
    }

    public PremiumAccount(string userName, short currentRating, short bonusForWin) : base(
        new List<GameStat>(), userName,
        currentRating)
    {
        this._bonusForWin = bonusForWin;
    }

    public PremiumAccount(string userName) : base(new List<GameStat>(), userName,
        500)
    {
        this._bonusForWin = DefaultBonusForWin;
    }


    public override void WinGame(Game game)
    {
        short totalRate;

        if (IsLastThreeGameIsWin())
            totalRate = (short)(game.BidRating * _bonusForWin);
        else
            totalRate = game.BidRating;

        if (game.GetType() != typeof(TrainingGame))
        {
            if (CurrentRating + totalRate < MaxRate)
            {
                this.CurrentRating += totalRate;
            }
            else
                this.CurrentRating = MaxRate;
        }

        GameStats.Add(new GameStat(game.Type, game.Opponent1.UserName, game.Opponent2.UserName, totalRate));
    }

    public override void LoseGame(Game game)
    {
        short totalRate;

        if (IsLastThreeGameIsWin())
            totalRate = (short)(game.BidRating / (2 * _bonusForWin));
        else
            totalRate = (short)(game.BidRating / 2);

        if (game.GetType() != typeof(TrainingGame))
        {
            if (CurrentRating - totalRate > 1)
            {
                this.CurrentRating -= totalRate;
            }
            else
                this.CurrentRating = 1;
        }

        GameStats.Add(new GameStat(game.Type, game.Opponent1.UserName, game.Opponent2.UserName, game.BidRating));
    }

    private Boolean IsLastThreeGameIsWin()
    {
        var countOfWinGames = 0;
        for (int i = GameStats.Capacity - 1; i >= 0; i++)
        {
            if (GameStats[i].WinnerOpponent.Equals(this.UserName))
            {
                countOfWinGames++;
            }
        }

        return countOfWinGames >= 3;
    }

    public override string GetStats()
    {
        var report = new System.Text.StringBuilder();

        report.AppendLine(
            $"User:\t{this.UserName}\nGame Number\tType\t\tWinner\t\tLoser\t\tBit Rate\tBonus for win");


        for (var i = 0; i < GameStats.Count; i++)
        {
            report.AppendLine($"{i + 1}\t\t{GameStats[i].TypeOfGame}\t\t{GameStats[i].WinnerOpponent}" +
                              $"\t\t{GameStats[i].LoserOpponent}\t" +
                              $"\t{GameStats[i].GameRate}\t\t{this._bonusForWin}");
        }

        return report.ToString();
    }
}