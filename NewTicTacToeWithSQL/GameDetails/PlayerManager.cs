namespace NewTicTacToeWithSQL.GameDetails
{
    internal class PlayerManager
    {
        //Method 1: that returns X or O depending the player!
        public char GetMark(ref int playerNumber)
        {
            char symbol = playerNumber == 1 ? 'X' : 'O';
            playerNumber = playerNumber == 1 ? 2 : 1;
            return symbol;
        }

        //Method 2: getting players Names!
        public void GetName(ref string player1, ref string player2)
        {
            Console.Write("Enter Player 1 name: ");
            player1 = Console.ReadLine();
            Console.Write("Enter Player 2 name: ");
            player2 = Console.ReadLine();
        }

        //Method 3: getting info about who's turn is it!
        public void GetTurnInfo(int playerNumber, string player1 , string player2) 
        {
            if (playerNumber == 1)
                Console.WriteLine("it is {0}'s turn", player1);
            
            else
                Console.WriteLine("it is {0}'s turn", player2);
        }

        //Method 4: Getting info about who has won the game!
        public void GetWiningInfo(char symbol, string player1, string player2) 
        {
            if (symbol == 'X')
                Console.WriteLine("{0} has won the game! ", player1);
            else 
                Console.WriteLine("{0} has won the game! ", player2);

            Console.WriteLine();
        }
    }
}