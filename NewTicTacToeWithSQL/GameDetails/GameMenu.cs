using NewTicTacToeWithSQL.DataAccess;
using NewTicTacToeWithSQL.Entities;

namespace NewTicTacToeWithSQL.GameDetails
{
    internal class GameMenu
     {
        //Declaring fields!
        private string choice;
        private bool isOn = true;
        private List<Game> games = new List<Game>();
        private List<char> playingBoardList = new List<char>();
        private TicTacToeGame ticTacToeGame;
        private LoadGame loadGame;
        private ReadDbInfo readDbInfo = new ReadDbInfo();
        private DeleteDbInfo deleteDbInfo = new DeleteDbInfo();
        private PlayerManager playerManager = new PlayerManager();
        private string player1;
        private string player2;
        private int playerNumber = 1;
        private bool isLoadedGame = true;
        private int idNumber;

        //Method that loops menu!
        public void MenuChoice()
        {
            while (isOn)
            {
                choice = MenuOption.MenuOptionChoice();

                switch (choice)
                {
                    //if the player wants to play new game!
                    case "1":
                        Board.EmptyBoardList(playingBoardList);
                        playerManager.GetName(ref player1, ref player2);
                        ticTacToeGame = new TicTacToeGame(playingBoardList, player1, player2, playerNumber);
                        ticTacToeGame.SaveGameAndUsers();
                        Console.WriteLine("Welcome to Nick' TicTacToe Game");
                        Board.DisplayBoard(playingBoardList);
                        ticTacToeGame.StartGame();
                        Console.WriteLine("HIT ANNY KEY TO LEAVE THE GAME!");
                        isOn= false;
                        break;

                    // if player wants to load the game!
                    case "2":
                        loadGame = new LoadGame();
                        Board.EmptyBoardList(playingBoardList);
                        games = readDbInfo.GetAllGames();
                        MenuOption.DisplayGameInfoInMenu(games);
                        idNumber = MenuOption.GameIdChoice();

                        // if input is  valid load the game else return to main menu!
                        if (readDbInfo.IsIdNumberValid(idNumber))
                        {
                            loadGame.GetNamesAndMovesFromDatabase(idNumber, ref player1, ref player2, playingBoardList, ref playerNumber);
                            ticTacToeGame = new TicTacToeGame(playingBoardList, player1, player2, playerNumber);
                            ticTacToeGame.StartGame(isLoadedGame, idNumber);
                            Console.WriteLine("HIT ANNY KEY TO LEAVE THE GAME!");
                            isOn = false;
                        }
                        else
                        {
                            Console.Clear();
                            MenuOption.Menu();
                            MenuChoice();
                        }
                        break;
                    
                    // if player wants to delete the game from database!
                    case "3":
                        games = readDbInfo.GetAllGames();
                        MenuOption.DisplayGameInfoInMenu(games);
                        idNumber = MenuOption.GameIdChoice();

                        if (readDbInfo.IsIdNumberValid(idNumber))
                        {
                            deleteDbInfo.DeleteInfo(idNumber);
                            Console.WriteLine("...Done!");
                            Console.WriteLine("PRESS ANY KEY");
                            Console.ReadKey();
                        }
                        Console.Clear();
                        MenuOption.Menu();
                        MenuChoice();
                        
                        break;

                    // if player wants to end the program!
                    case "Q":
                        isOn = false;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}