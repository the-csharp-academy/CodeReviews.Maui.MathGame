
using MathGame.GameLogic;
using MathGame.PreviousGames;
using MathGame.UserInterface;
using Spectre.Console;
bool isRunning = true;


GamesTable gameTable = new();

UserInterface mainMenu = new MainMenu();
UserInterface viewPreviousGames = new ViewPreviousGames(gameTable);
UserInterface gameTypeMenu = new GameType();
UserInterface additionGame = new Game(Enums.GameType.Addition, gameTable);
UserInterface subtractionGame = new Game(Enums.GameType.Subtraction, gameTable);
UserInterface multiplcationGame = new Game(Enums.GameType.Multiplication, gameTable);
UserInterface divisionGame = new Game(Enums.GameType.Division, gameTable);




Enums.InterfaceName activeInterface = Enums.InterfaceName.Main;


while (isRunning)
{
    switch(activeInterface)
    {
        case Enums.InterfaceName.Main:
            activeInterface = mainMenu.DisplayAndTakeInput();
            break;

        case Enums.InterfaceName.GameType:
            activeInterface = gameTypeMenu.DisplayAndTakeInput();
            break;


        case Enums.InterfaceName.PreviousGames:
            activeInterface = viewPreviousGames.DisplayAndTakeInput();
            break;

        case Enums.InterfaceName.AdditionGame:
            activeInterface = additionGame.DisplayAndTakeInput();
            break;

        case Enums.InterfaceName.SubtractionGame:
            activeInterface = subtractionGame.DisplayAndTakeInput();
            break;


        case Enums.InterfaceName.MultiplicationGame:
            activeInterface = multiplcationGame.DisplayAndTakeInput();
            break;

        case Enums.InterfaceName.DivisionGame:
            activeInterface = divisionGame.DisplayAndTakeInput();
            break;


        case Enums.InterfaceName.Exit:
            isRunning = false;
            break;


    }  
}
