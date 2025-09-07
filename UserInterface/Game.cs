using MathGame.GameLogic;
using MathGame.PreviousGames;
using System.Runtime.CompilerServices;
using System.Timers;

namespace MathGame.UserInterface;


internal class Game : UserInterface
{
    internal int score = 0;
    internal int numOfQuestions = 10;
    internal string GameType;
    internal GamesTable GameTable;
    internal Problem problem;


    internal Game(Enums.GameType gameType, GamesTable gameTable) 
    {

        GameTable = gameTable;
        GameType = gameType.ToString();

        switch (gameType)
        {
            case Enums.GameType.Addition:

                problem = new AdditionProblem();
                break;

            case Enums.GameType.Subtraction:

                problem = new SubtractionProblem();
                break;

            case Enums.GameType.Multiplication:
                problem = new MultiplicationProblem();
                break;

            case Enums.GameType.Division:
                problem = new DivisionProblem();
                break;
            default:
                throw new ArgumentException("Invalid Game Type");
  
        }
    }
    internal override Enums.InterfaceName DisplayAndTakeInput()
    {
        

        for (int i = 0; i < numOfQuestions; i++)
        {
            bool validInput = false;
            int inputInt = 0;
            string? readResult;

            (string problemString, int solution) newProblem = problem.NewProblem();

            do
            {
                Console.Clear();
                Console.WriteLine(newProblem.problemString);

                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    validInput = int.TryParse(readResult.Trim(), out inputInt);
                }

            } while (!validInput);

            if (inputInt == newProblem.solution)
            {
                score++;
            }
        }

        Console.WriteLine($"You got {score} out of {numOfQuestions} correct!");

        GameRecord gameRecord = new (GameType, score.ToString());
        GameTable.AddRow(gameRecord);

        Console.WriteLine("\n Press Any Key to Return to the Menu");
        Console.ReadLine();
        Console.Clear();


        return Enums.InterfaceName.Main;
    }
}