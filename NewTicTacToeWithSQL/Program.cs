using NewTicTacToeWithSQL.GameDetails;

namespace NewTicTacToeWithSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuOption.Menu();
            GameMenu gameMenu = new GameMenu();
            gameMenu.MenuChoice();
        }   
      }
    }