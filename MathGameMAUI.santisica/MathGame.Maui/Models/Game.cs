using SQLite;

namespace MathGame.Maui.Models;

[SQLite.Table("game")]
public class Game
{
    [PrimaryKey, AutoIncrement, SQLite.Column("Id")]
    public int Id { get; set; }
    public DateTime DatePlayed { get; set; }
    public GameOperation Type { get; set; }
    public int Score { get; set; }
}

public enum GameOperation
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
}
