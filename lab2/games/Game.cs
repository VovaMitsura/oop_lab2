namespace lab2.games;

using accounts;

public abstract class Game
{
    private const string ExceptionMessageNegativeBidRating = "Bid rate cannot be negative";

    public Account Opponent1 { get; }
    public Account Opponent2 { get; }

    public string Type { get; protected init; }

    private readonly short _bidRating;

    public short BidRating
    {
        get => _bidRating;
        protected init =>
            _bidRating = value < 0
                ? throw new ArgumentException(ExceptionMessageNegativeBidRating, nameof(value))
                : value;
    }

    protected Game(string typeOfGame, Account opponent1, Account opponent2, short bidRating)
    {
        Type = typeOfGame;
        Opponent1 = opponent1;
        Opponent2 = opponent2;
        BidRating = bidRating;
    }

    protected Game(Account opponent1, Account opponent2)
    {
        Opponent1 = opponent1;
        Opponent2 = opponent2;
        Type = "Abstract";
    }

    public abstract void Play();

    protected virtual void SetWinnerAndLoser(Account winner, Account loser)
    {
        winner.WinGame(this);
        loser.LoseGame(this);
    }
}