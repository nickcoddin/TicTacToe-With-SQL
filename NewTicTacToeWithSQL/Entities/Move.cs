namespace NewTicTacToeWithSQL.Entities
{
    internal class Move
    {
        public int Id { get; set; }
        // Foreign key 
        public int GameId { get; set; }
        public Game Game { get; set; }
        public char Symbol { get; set; } 
        public int Index { get; set; }    
    }
}