using NewTicTacToeWithSQL.DataAccess;
using NewTicTacToeWithSQL.Entities;

namespace NewTicTacToeWithSQL.GameDetails
{
    internal class RetrievedInfoFromDatabase
    {
        ReadDbInfo readDbInfo = new ReadDbInfo();

        //Method 1: it is Getting names from User database!
        public void GetNamesFromUser(int idNmuber, out string player1, out string player2)
        {
            List<User> users = readDbInfo.GetUsers(idNmuber);
            player1 = string.Empty;
            player2 = string.Empty;

            for (int i = 0; i < users.Count; i++)
            {
                if ((i % 2) == 0) 
                { 
                    player1 = users[i].Name;
                }
                else
                {
                    player2 = users[i].Name;
                }
            }
        }

        //Method 2: it is Returning player number base on how many moves are made!
        public void ReturnPlayerNumberFromMove(int idNmuber, ref int playerNumber)
        {
            //int playerNumber;
            List<Move> moves = readDbInfo.GetMoves(idNmuber);

            if (moves.Count % 2 == 0)
            {
                playerNumber = 1;
            }
            else playerNumber = 2;
        }

        //Method 3: getting loaded board from Move database!
        public void GetLoadedBoard(int idNmuber, List<char> loadedBoardList)
        {
            List<Move> moves = readDbInfo.GetMoves(idNmuber);

            foreach (var move in moves)
            {
                loadedBoardList[move.Index - 1] = move.Symbol;
            }
        }
    }
}