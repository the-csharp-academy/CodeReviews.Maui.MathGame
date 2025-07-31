
using SQLite;

namespace MathGameMaui.Models
{
    [Table("game")]
    public class Game
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        public GameOperation Type { get; set; }
        public int Score { get; set; }
        public DateTime DatePlayed { get; set; }

    }


    public enum GameOperation
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}
