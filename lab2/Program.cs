using lab2.accounts;
using lab2.games;

namespace lab2;

public class Program
{
    public static void Main(string[] args)
    {
        AbstractGameFactory gameFactory = new GamesFactoryWithDefaultRates();

        /*Basic account*/
        Account johnBasicAccount = new BasicAccount("John");
        Account jackBasicAccount = new BasicAccount("Jack");

        var basicGame = gameFactory.CreateBasicGame(jackBasicAccount, johnBasicAccount);
        basicGame.Play();

        Console.WriteLine(jackBasicAccount.GetStats());
        Console.WriteLine(jackBasicAccount.CurrentRating);
        Console.WriteLine(johnBasicAccount.CurrentRating);

        /*Training*/
        Account jackTrainingAccount = new TrialAccount();
        
        var trainingGame = gameFactory.CreateTrainingGame(jackTrainingAccount);
        trainingGame.Play();

        Console.WriteLine(jackTrainingAccount.GetStats());
        Console.WriteLine(jackTrainingAccount.CurrentRating);

        /*Premium*/
        Account jackPremiumAccount = new PremiumAccount("Jack");
        Account johnPremiumAccount = new PremiumAccount("John");

        var goldenGame = gameFactory.CreateGoldenGame(jackPremiumAccount, johnPremiumAccount);
        goldenGame.Play();

        Console.WriteLine(jackPremiumAccount.GetStats());
        Console.WriteLine(jackPremiumAccount.CurrentRating);
        Console.WriteLine(johnPremiumAccount.CurrentRating);

        /*Try to create game with default accounts and caught error */
        try
        {
            gameFactory.CreateGoldenGame(jackBasicAccount, johnBasicAccount);
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }
}