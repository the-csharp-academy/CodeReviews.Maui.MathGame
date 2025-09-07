using MathGame.PreviousGames;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.UserInterface;

internal class GameType : UserInterface
{
    private readonly string Title = "Choose a Game Type:";
    private enum MenuSelection
    {
        Add,
        Subtract,
        Divide,
        Multiply,
        Back,
        Exit
    }
    private readonly Selection<MenuSelection>[] menuChoices = [
        new Selection<MenuSelection>(MenuSelection.Add, "Addition"),
        new Selection<MenuSelection>(MenuSelection.Subtract, "Subtraction"),
        new Selection<MenuSelection>(MenuSelection.Multiply, "Multiplication"),
        new Selection<MenuSelection>(MenuSelection.Divide, "Division"),
        new Selection<MenuSelection>(MenuSelection.Back, "Back to Main Menu"),
        new Selection<MenuSelection>(MenuSelection.Exit, "Exit Program")
    ];
    internal override Enums.InterfaceName DisplayAndTakeInput()
    {
        var selection = AnsiConsole.Prompt(
             new SelectionPrompt<Selection<MenuSelection>>()
             .Title(Title)
             .AddChoices(menuChoices)
             .UseConverter(s => s.DisplayString)
             );
        var selectionEnum = selection.SelectionEnum;

        switch (selectionEnum)
        {
            case MenuSelection.Add:
                return Enums.InterfaceName.AdditionGame;

            case MenuSelection.Subtract:
                return Enums.InterfaceName.SubtractionGame;

            case MenuSelection.Multiply:
                return Enums.InterfaceName.MultiplicationGame;

            case MenuSelection.Divide:
                return Enums.InterfaceName.DivisionGame;

            case MenuSelection.Back:
                return Enums.InterfaceName.Main;

            case MenuSelection.Exit:
                return Enums.InterfaceName.Exit;

            default:
                throw new NotImplementedException("Default Returned for Menu Choice");
        }
    }
}
