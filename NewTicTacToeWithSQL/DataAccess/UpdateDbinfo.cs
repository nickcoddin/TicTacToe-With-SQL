using Microsoft.EntityFrameworkCore;
using NewTicTacToeWithSQL.Entities;
namespace NewTicTacToeWithSQL.DataAccess
{
    internal class UpdateDbinfo
    {
        //Method 1: that updates the Loaded game boad!
        public void UpdateMoveToDatabase(char symbol, int index, int idNumber)
        {
            using (var db = new ApplicationDbContext())
            {
                var game = db.Games.Include(g => g.Moves).SingleOrDefault(g => g.Id == idNumber);
                if (game != null)
                {
                    var move = new Move { GameId = game.Id, Symbol = symbol, Index = index };
                    game.Moves.Add(move);
                    db.SaveChanges();
                }
            }
        }
    }
}