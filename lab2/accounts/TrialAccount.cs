using lab2.games;

namespace lab2.accounts;

public class TrialAccount : Account
{
    private short _countOfAcceptedGames;
    private const short DefaultCountOfAcceptedGames = 10;
    private const short MaxRateForTrainingAccount = 15;

    public TrialAccount(short countOfAcceptedGames) : base(
        new List<GameStat>(), "Trial Account", 0)
    {
        this._countOfAcceptedGames = countOfAcceptedGames;
    }

    public TrialAccount() : base(
        new List<GameStat>(), "Trial Account", 0)
    {
        this._countOfAcceptedGames = DefaultCountOfAcceptedGames;
    }

    public override void WinGame(Game game)
    {
        if (GameStats.Count >= _countOfAcceptedGames--) return;

        if (game.GetType() != typeof(TrainingGame))
        {
            if (CurrentRating + 1 < MaxRateForTrainingAccount)
            {
                this.CurrentRating++;
            }
            else
                this.CurrentRating = MaxRateForTrainingAccount;
        }
        
        GameStats.Add(new GameStat(game.Type, game.Opponent1.UserName, game.Opponent2.UserName, game.BidRating));
    }

    public override void LoseGame(Game game)
    {
        if (GameStats.Count >= _countOfAcceptedGames--) return;

        if (game.GetType() != typeof(TrainingGame))
        {
            if (CurrentRating - game.BidRating > 0)
            {
                this.CurrentRating -= game.BidRating;
            }
            else
                this.CurrentRating = 1;
        }

        GameStats.Add(new GameStat(game.Type, game.Opponent2.UserName, game.Opponent1.UserName, game.BidRating));
    }

    public override string GetStats()
    {
        var report = new System.Text.StringBuilder();

        report.AppendLine(
            $"User:\t{this.UserName}\nGame Number\tType\t\tWinner\t\tLoser\t\tBit Rate\tCount of left games");


        for (var i = 0; i < GameStats.Count; i++)
        {
            report.AppendLine($"{i + 1}\t\t{GameStats[i].TypeOfGame}\t{GameStats[i].WinnerOpponent}" +
                              $"\t{GameStats[i].LoserOpponent}\t" +
                              $"\t{GameStats[i].GameRate}\t\t{this._countOfAcceptedGames}");
        }

        return report.ToString();
    }
}