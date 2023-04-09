using NewTicTacToeWithSQL.Entities;

namespace NewTicTacToeWithSQL.DataAccess
{
    internal class ReadDbInfo
    {
        // Method 1: that returns game  from Game database!
        public List<Game> GetAllGames()
        {
            using (var db = new ApplicationDbContext())
            {
                // retrieve all Game objects from the database
                var games = db.Games.ToList();

                return games;
            }
        }

        // Method 2: that returns user names from User database!
        public List<User> GetUsers(int gameID)
        {
            using (var db = new ApplicationDbContext())
            {
                var users = db.Users
                              .Where(u => u.GameId == gameID)
                              .ToList();

                return users;
            }
        }

        // Method 3: that returns moves from Move database!
        public List<Move> GetMoves(int gameID)
        {
            using (var db = new ApplicationDbContext())
            {
                var moves = db.Moves
                                .Where(u => u.GameId == gameID)
                                .ToList();
                return moves;
            }
        }
    }
} 