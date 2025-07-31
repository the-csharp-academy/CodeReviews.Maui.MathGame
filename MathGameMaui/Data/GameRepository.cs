using MathGameMaui.Models;
using SQLite;

namespace MathGameMaui.Data
{
    public class GameRepository
    {
        string _dbPath;
        private SQLiteConnection _conn;

        public GameRepository(string dbPath)
        {
            _dbPath = dbPath;
            Init();
        }

        public void Init() {
            if (_conn != null)
                return;

            _conn = new SQLiteConnection(_dbPath);
            _conn.CreateTable<Game>();
        }

        public List<Game> GetAllGames()
        {
            return _conn.Table<Game>()
                .OrderByDescending(g => g.DatePlayed)
                .ToList();
        }

        public void Add(Game game)
        {
            _conn.Insert(game);
        }

        public void Delete(int id) {
            _conn.Delete<Game>(id);
        }
    }
}
