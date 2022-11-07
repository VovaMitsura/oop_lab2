using lab2.accounts;

namespace lab2.games;

public class GamesFactoryWithDefaultRates : AbstractGameFactory
{
    private const short BasicGameRate = 10;
    private const short BasicTrainRate = 1;
    private const short BasicGolderRate = 120;


    public override Game CreateBasicGame(Account opponent1, Account opponent2)
    {
        return new BasicGame(opponent1, opponent2, BasicGameRate);
    }

    public override Game CreateTrainingGame(Account opponent)
    {
        return new TrainingGame(opponent, BasicTrainRate);
    }

    public override Game CreateGoldenGame(Account opponent1, Account opponent2)
    {
        return new GoldenGame(opponent1, opponent2, BasicGolderRate);
    }
}