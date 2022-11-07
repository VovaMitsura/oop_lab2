using lab2.accounts;

namespace lab2.games;

public abstract class AbstractGameFactory
{
    public abstract Game CreateBasicGame(Account opponent1, Account opponent2);
    public abstract Game CreateTrainingGame(Account opponent);
    public abstract Game CreateGoldenGame(Account opponent1, Account opponent2);

}