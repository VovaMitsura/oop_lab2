using lab2.accounts;

namespace lab2.games;

public class GoldenGame : Game
{
    private const string ExceptionMessageToLowRate = "Golden`s bid rating cannot be lower than 100";
    private const string ExceptionMessageNotPermitted = "Only golden account can be passed to constructor parameters";


    public GoldenGame(Account opponent1, Account opponent2, short bidRating) : base(opponent1,
        opponent2)
    {
        if (opponent1.GetType() != typeof(PremiumAccount) || opponent1.GetType() != typeof(PremiumAccount))
        {
            throw new UnauthorizedAccessException(ExceptionMessageNotPermitted);
        }

        Type = "Golden";
        BidRating = bidRating < 100 ? throw new UnauthorizedAccessException(ExceptionMessageToLowRate) : bidRating;
    }

    public override void Play()
    {
        var firstUserCloseToWin = Math.Abs(Opponent1.CurrentRating - BidRating);
        var secondUserCloseToWin = Math.Abs(Opponent2.CurrentRating - BidRating);

        if (firstUserCloseToWin < secondUserCloseToWin)
        {
            SetWinnerAndLoser(Opponent1, Opponent2);
        }
        else if (firstUserCloseToWin > secondUserCloseToWin)
        {
            SetWinnerAndLoser(Opponent2, Opponent1);
        }
        else
        {
            Random random = new Random();
            var winner = random.NextInt64(0, 2);

            if (winner == 0)
            {
                SetWinnerAndLoser(Opponent1, Opponent2);
            }
            else
                SetWinnerAndLoser(Opponent2, Opponent1);
        }
    }
}