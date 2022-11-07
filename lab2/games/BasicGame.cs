using lab2.accounts;

namespace lab2.games;

public class BasicGame : Game
{
    private const string ExceptionMessageNotPermitted = "Basis`s bid rating caonnot be higher 100";

    public BasicGame(Account opponent1, Account opponent2, short bidRating) : base(opponent1, opponent2)
    {
        BidRating = bidRating > 100 ? throw new UnauthorizedAccessException(ExceptionMessageNotPermitted) : bidRating;
        Type = "Basic Game";
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