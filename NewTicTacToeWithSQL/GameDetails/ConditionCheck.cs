namespace NewTicTacToeWithSQL.GameDetails
{
    internal static class ConditionCheck 
    {
        //Method 1: checks if there is a winner!
        public static bool IsWin(char mark, List<char> boardList)
        {
            // Check for horizontal win!
            for (int row = 0; row < Consts.ROWS; row++)
            {
                int count = 0;
                for (int col = 0; col < Consts.COLS; col++)
                {
                    int index = row * Consts.COLS + col;
                    if (boardList[index] == mark)
                    {
                        count++;
                    }
                }
                if (count == Consts.COLS)
                {
                    return true;
                }
            }

            // Check for vertical win!
            for (int col = 0; col < Consts.COLS; col++)
            {
                int count = 0;
                for (int row = 0; row < Consts.ROWS; row++)
                {
                    int index = row * Consts.COLS + col;
                    if (boardList[index] == mark)
                    {
                        count++;
                    }
                }
                if (count == Consts.ROWS)
                {
                    return true;
                }
            }

            // Check for diagonal win (top-left to bottom-right)!
            int diagonalCount1 = 0;
            for (int i = 0; i < Consts.CELLNUMBER; i += (Consts.COLS + 1))
            {
                if (boardList[i] == mark)
                {
                    diagonalCount1++;
                }
            }
            if (diagonalCount1 == Consts.COLS)
            {
                return true;
            }

            // Check for diagonal win (top-right to bottom-left)!
            int diagonalCount2 = 0;
            for (int i = Consts.COLS - 1; i < Consts.CELLNUMBER - 1; i += (Consts.COLS - 1))
            {
                if (boardList[i] == mark)
                {
                    diagonalCount2++;
                }
            }
            if (diagonalCount2 == Consts.COLS)
            {
                return true;
            }
            // No win found!
            return false;
        }

        //Method 2: checks if there is a Draw!
        public static bool IsDraw(List<char> boardList)
        {
            int count = 0;
            foreach (char c in boardList)
            {
                if (c != ' ')
                {
                    count++;
                }
            }
            return count == Consts.CELLNUMBER;
        }
    }
}