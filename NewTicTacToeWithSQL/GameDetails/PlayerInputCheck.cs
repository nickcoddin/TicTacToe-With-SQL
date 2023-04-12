using NewTicTacToeWithSQL.Entities;

namespace NewTicTacToeWithSQL.GameDetails
{
    internal static class PlayerInputCheck
    {
        //Method 1: checks if the Cell is occupied or not !
        public static bool IsOccupied(List<char> boardList, string playerInputString)
        {
            int playerInput = int.Parse(playerInputString);
            if (boardList[playerInput - 1] != ' ')
                return true;
            else
                return false;
        }

        //Method 2: checks if the player input is valid or not!
        public static  bool IsValidInput(string playerInputString)
        {
            int playerInput;
            if (int.TryParse(playerInputString, out playerInput))
            {
                // Parsing succeeded, check if the input is between 1 to 9!
                if (playerInput >= 1 && playerInput <= 9)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}