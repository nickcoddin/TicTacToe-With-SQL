namespace NewTicTacToeWithSQL.Entities
{
    internal class Game
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public List<User> Users { get; set; }
        public List<Move> Moves { get; set; }
    }
}