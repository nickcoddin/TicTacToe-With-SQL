using NewTicTacToeWithSQL.GameDetails;

namespace NewTicTacToeWithSQL
{
    internal static class Board
    {
        // Method 1: cleares and returns starting board!
        public static void EmptyBoardList(List<char> boardList)
        {
            char freeSpace = ' ';
            for (int i = 0; i < Consts.CELLNUMBER; i++)
            {
                boardList.Add(freeSpace);    
            }
        }

        // Method 2: displays playing Board in Console!
        public static void DisplayBoard(List<char> boardList)
        {
            Console.Clear();
            Console.WriteLine(" -------------");
            for (int row = 0; row < Consts.ROWS; row++)
            {
                for (int col = 0; col < Consts.COLS; col++)
                {
                    int index = row * Consts.COLS + col + 1;
                    char value = boardList[index - 1];

                    if (col == 0)
                    {
                        Console.Write(" |");
                    }
                    Console.Write(" {0} |", value);
                }
                Console.WriteLine();
                Console.WriteLine(" -------------");
            }
            Console.WriteLine();
        }
    }
}