using lab2.accounts;

namespace lab2.games;

public class TrainingGame : Game
{
    private const string ExceptionMessageNotPermitted = "Train`s bid rating cannot be higher 10";

    public TrainingGame(Account opponent1, short trainingRate) : base(opponent1, new BasicAccount("Bot"))
    {
        Type = "Training";
        BidRating = trainingRate > 10
            ? throw new UnauthorizedAccessException(ExceptionMessageNotPermitted)
            : trainingRate;
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