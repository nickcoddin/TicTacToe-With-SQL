namespace NewTicTacToeWithSQL.Entities
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign key 
        public int GameId { get; set; }
        public Game Game { get; set; }
        
    }
}