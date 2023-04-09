using NewTicTacToeWithSQL.DataAccess;
using NewTicTacToeWithSQL.Entities;

namespace NewTicTacToeWithSQL.GameDetails
{
    internal class TicTacToeGame
    {
        //Declaring fields
        private List<char> playingBoardList;
        private Game game;
        private PlayerManager playerManager ;
        private CreateDbInfo createDbInfo;
        private UpdateDbinfo updateDbinfo;
        private int playerNumber;
        private bool gameOn = true;
        private char symbol;
        private string player1;
        private string player2;
        private bool gameWon = false;

        // Constructor!
        public TicTacToeGame(List<char> playingBoardList, string player1, string player2, int playerNumber)
        {
            this.playingBoardList = playingBoardList;
            this.player1 = player1;
            this.player2 = player2;
            this.playerNumber = playerNumber;
            playerManager = new PlayerManager();
            createDbInfo = new CreateDbInfo();
            updateDbinfo= new UpdateDbinfo();
            game = new Game();
        }

        // Method 1: that Saves Game and User information!
        public void SaveGameAndUsers() {

            createDbInfo.AddGame(game);
            createDbInfo.AddUser(player1, game);
            createDbInfo.AddUser(player2, game);
        }

        // Method 2: that checks the state of the game!
        private void StateCheck()
        {
            if (ConditionCheck.IsWin('X', playingBoardList) || ConditionCheck.IsWin('O', playingBoardList))
            {
                Board.DisplayBoard(playingBoardList);
                char winningSymbol = ConditionCheck.IsWin('X', playingBoardList) ? 'X' : 'O';
                playerManager.GetWiningInfo(winningSymbol, player1, player2);
                gameOn = false;
            }
            else if (ConditionCheck.IsDraw(playingBoardList))
            {
                Board.DisplayBoard(playingBoardList);
                Console.WriteLine("  it is a Tie! \n   GAME OVER!");
                Console.WriteLine();
                gameOn = false;
            }
        }

        // Method 3: contains Game loop!
        public void StartGame(bool isLoadGame = false, int idNumber = 0)
        {

            Console.Clear();
            do
            {
                // displaying playing board and versus line!
                Console.WriteLine();
                Board.DisplayBoard(playingBoardList);
                Console.WriteLine(" {0}(X) VS {1}(O)", player1, player2);

                playerManager.GetTurnInfo(playerNumber, player1, player2);

                // using console input method!
                Console.Write("Please Enter a number 1 to 9: ");
                string playerInputString = Console.ReadLine();
                Console.WriteLine();

                // checking winning conditions for Loading game!
                StateCheck();

                // checking if input is valid!
                if (gameOn && PlayerInputCheck.IsValidInput(playerInputString))
                {
                    // checking if cell is Free!
                    if(!PlayerInputCheck.IsOccupied(playingBoardList, playerInputString))
                    {
                        //Putting symbols on board!
                        symbol = playerManager.GetMark(ref playerNumber);
                        int playerInput = int.Parse(playerInputString);
                        playingBoardList[playerInput - 1] = symbol;


                        // if it is load game checks the conditions and updates the board! 
                        if (isLoadGame)
                        {
                            updateDbinfo.UpdateMove(symbol, playerInput, idNumber);
                        }
                        else
                            createDbInfo.AddMove(symbol, playerInput, game);

                        // checking winning conditions!
                        StateCheck();
                    }
                }
            } while (gameOn);
        }
    }
}