using lab2.games;

namespace lab2.accounts;

public class BasicAccount : Account
{
    private const short MaxRateForBasicAccount = 15000;
    public BasicAccount(string userName)
        : base(new List<GameStat>(), userName, 1)
    {
    }

    public override void WinGame(Game game)
    {
        if (game.GetType() != typeof(TrainingGame))
        {
            if (CurrentRating + 1 < MaxRateForBasicAccount)
            {
                this.CurrentRating++;
            }
            else
                this.CurrentRating = MaxRateForBasicAccount;
        }

        GameStats.Add(new GameStat(game.Type, game.Opponent1.UserName, game.Opponent2.UserName, game.BidRating));
    }

    public override void LoseGame(Game game)
    {
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
}