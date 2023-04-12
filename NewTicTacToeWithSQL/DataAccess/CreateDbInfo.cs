using NewTicTacToeWithSQL.Entities;
using NewTicTacToeWithSQL.Migrations;

namespace NewTicTacToeWithSQL.DataAccess
{
      internal class CreateDbInfo
    {
        //Method 1: Adds time in database!
        public void AddGame(Game game)
        {
            using (var db = new ApplicationDbContext())
            {
                game.TimeStamp = DateTime.Now;  
                db.Add(game);
                db.SaveChanges();

            }
        }

        //Method 2: Adds symbols and indexes in database according to the GameID (Foreign Key)!
        public void AddMove(char symbol, int index, int gameId)
        {
            using (var db = new ApplicationDbContext())
            {
                var move = new Move { GameId = gameId, Symbol = symbol, Index = index};
                db.Add(move);
                db.SaveChanges();
            }
        }

        //Method 3: Adds names in database according to the GameID (FK)!
        public void AddUser(string playerName, int gameId)
        {
            using (var db = new ApplicationDbContext())
            {
                var user = new User { GameId = gameId, Name = playerName };
                db.Add(user);
                db.SaveChanges();
            }
        }
    }
}