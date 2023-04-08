using NewTicTacToeWithSQL.Entities;

namespace NewTicTacToeWithSQL.DataAccess
{
    internal class CreateDbInfo
    {
        Game game = new Game();

        //Method 1: Adds time in database!
        public void AddGameToDatabase()
        {
            using (var db = new ApplicationDbContext())
            {
                game.TimeStamp = DateTime.Now;  
                db.Add(game);
                db.SaveChanges();

            }
        }

        //Method 2: Adds symbols and indexes in database according to the GameID (FK)!
        public void AddMoveToDatabase(char symbol, int index)
        {
            using (var db = new ApplicationDbContext())
            {
                var move = new Move { GameId = game.Id, Symbol = symbol, Index = index};
                db.Add(move);
                db.SaveChanges();
            }
        }

        //Method 3: Adds names in database according to the GameID (FK)!
        public void AddUserToDatabase(string playerName)
        {
            using (var db = new ApplicationDbContext())
            {
                var user = new User { GameId = game.Id, Name = playerName };
                db.Add(user);
                db.SaveChanges();
            }
        }
    }
}