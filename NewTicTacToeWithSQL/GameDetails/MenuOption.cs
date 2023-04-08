using NewTicTacToeWithSQL.Entities;

namespace NewTicTacToeWithSQL.GameDetails
{
    internal static class MenuOption
    {
        //Method 1: it is creating menu display!
        public static void Menu()
        {
            Console.WriteLine("         MENU");
            Console.WriteLine();
            Console.WriteLine("  1. Play the game");
            Console.WriteLine("  2. Load the game");
            Console.WriteLine("  3. Delete Saved Info");
            Console.WriteLine("  Q. End the program");
            Console.WriteLine();

            Console.Write("Choose from 1, 2, 3 or Q: ");
        }

        // Method 2: Returning string input for menu!
        public static string MenuOptionChoice()
            {
                string choice;
                choice = Console.ReadLine().ToUpper();
                Console.WriteLine();

                return choice;
            }

        // Method 3: diplaying game information for menu from Game database!
        public static void DisplayGameInfoInMenu(List<Game> games)
        {
            Console.Clear();
            foreach (var game in games)
            {
                Console.WriteLine("{0} - {1}", game.Id, game.TimeStamp.ToString());
            }
        }

        //Method 2: Returning integer input to find game in database!!
        public static int GameIdChoice()
        {
            int idNumber;
            Console.Write("Please choose game number: ");
            string stringIdChoice = Console.ReadLine();
            int.TryParse(stringIdChoice, out idNumber);

            return idNumber;
        }
    }
}