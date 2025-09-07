using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathGame.PreviousGames;

namespace MathGame.UserInterface;

internal class ViewPreviousGames : UserInterface
{
    internal GamesTable GameTable { get; set; }
    internal ViewPreviousGames(GamesTable gameTable)
    {
        GameTable = gameTable;
    }
    internal override Enums.InterfaceName DisplayAndTakeInput()
    {
        Console.Clear();
        GameTable.Display();
        Console.WriteLine();
        Console.WriteLine("Press any key to continue");
        return Enums.InterfaceName.Main;
    }
}
