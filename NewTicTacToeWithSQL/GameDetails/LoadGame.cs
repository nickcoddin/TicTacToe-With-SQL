namespace NewTicTacToeWithSQL.GameDetails
{
    internal class LoadGame
    {
        private readonly RetrievedInfoFromDatabase retrievedInfoFromDatabase = new RetrievedInfoFromDatabase();

        //Method 1: Getting All information from Database to load the game!
        public void GetNamesAndMovesFromDatabase(int idNumber, ref string player1 ,ref string player2, List<char> loadedBoard, ref int playerNumber)
        {
            retrievedInfoFromDatabase.GetNamesFromUser(idNumber, out player1, out player2);
            retrievedInfoFromDatabase.ReturnPlayerNumberFromMove(idNumber,ref playerNumber);
            retrievedInfoFromDatabase.GetLoadedBoard(idNumber, loadedBoard);
        }
    }
}