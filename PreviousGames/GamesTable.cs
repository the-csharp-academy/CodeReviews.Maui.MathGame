using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.PreviousGames;

internal class GamesTable
{
    internal Table gamesTable;
    internal string[] columns  = ["Game #", "Game Type", "Score"];
    internal GamesTable()
    {

        gamesTable = new Table();
        foreach (var column in columns)
        {
            gamesTable.AddColumn(column);
        }
    }
    internal void Display()
    {
        AnsiConsole.Write(gamesTable);
    }

    internal void AddRow(GameRecord gameRecord)
    {
        string[] row = [GetRowCount(), gameRecord.GameType, gameRecord.Score];
        gamesTable.AddRow(row);
    }
    internal string GetRowCount()
    {
        return (gamesTable.Rows.Count + 1).ToString();
    }
    
}
