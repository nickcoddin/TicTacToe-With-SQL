namespace NewTicTacToeWithSQL.DataAccess
{
    internal class DeleteDbInfo
    {
        //Method 1: that Deletes all game related information according to the number player enters!
        public void DeleteInfo(int idNumber)
        {
            using (var db = new ApplicationDbContext())
            {
                // Delete all moves related to the game
                var moves = db.Moves.Where(m => m.GameId == idNumber);
                db.Moves.RemoveRange(moves);

                // Delete all users related to the game
                var users = db.Users.Where(u => u.GameId == idNumber);
                db.Users.RemoveRange(users);

                // Delete the game
                var game = db.Games.Find(idNumber);
                db.Games.Remove(game);

                db.SaveChanges();
            }
        }
    }
}

