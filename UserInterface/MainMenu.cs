using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.UserInterface;

internal class MainMenu : UserInterface
{
    private readonly string Title = "Main Menu";
    private enum MenuSelection
    {
        Play,
        ViewPreviousGames,
        Exit
    }

    private readonly Selection<MenuSelection>[] menuChoices = [
        new Selection<MenuSelection>(MenuSelection.Play, "Play"),
        new Selection<MenuSelection>(MenuSelection.ViewPreviousGames, "View Previous Games"),
        new Selection<MenuSelection>(MenuSelection.Exit, "Exit Program")
        ];

    internal override Enums.InterfaceName DisplayAndTakeInput()
    {
        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<Selection<MenuSelection>>()
            .Title(Title)
            .AddChoices(menuChoices)
            );
        MenuSelection selectionEnum = selection.SelectionEnum;

        switch (selectionEnum)
        {
            case MenuSelection.Play:
                return Enums.InterfaceName.GameType;

            case MenuSelection.ViewPreviousGames:
                return Enums.InterfaceName.PreviousGames;

            case MenuSelection.Exit:
                return Enums.InterfaceName.Exit;
            default:
                throw new NotImplementedException("Default Returned for Menu Choice");
        }
    }
}
