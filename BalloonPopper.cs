namespace BalloonPopsGame
{
    using System;

    public static class BalloonPopper
    {
        public static bool IsBalloonPopped(byte[,] gameBoard, int row, int col)
        {
            return gameBoard[row, col] == 0;
        }

        public static void PopBalloons(byte[,] gameBoard, int row, int col)
        {
            byte searchedTarget = gameBoard[row, col];
            gameBoard[row, col] = 0;
            CheckLeft(gameBoard, row, col, searchedTarget);
            CheckRight(gameBoard, row, col, searchedTarget);
            CheckUp(gameBoard, row, col, searchedTarget);
            CheckDown(gameBoard, row, col, searchedTarget);
        }

        private static void CheckLeft(byte[,] gameBoard, int row, int column, int searchedItem)
        {
            int newRow = row;
            int newColumn = column - 1;
            try
            {
                if (gameBoard[newRow, newColumn] == searchedItem)
                {
                    gameBoard[newRow, newColumn] = 0;
                    CheckLeft(gameBoard, newRow, newColumn, searchedItem);
                }
                else return;
            }
            catch (IndexOutOfRangeException)
            { return; }
        }

        private static void CheckRight(byte[,] gameBoard, int row, int column, int searchedItem)
        {
            int newRow = row;
            int newColumn = column + 1;
            try
            {
                if (gameBoard[newRow, newColumn] == searchedItem)
                {
                    gameBoard[newRow, newColumn] = 0;
                    CheckRight(gameBoard, newRow, newColumn, searchedItem);
                }
                else return;
            }
            catch (IndexOutOfRangeException)
            { return; }
        }

        private static void CheckUp(byte[,] gameBoard, int row, int column, int searchedItem)
        {
            int newRow = row + 1;
            int newColumn = column;
            try
            {
                if (gameBoard[newRow, newColumn] == searchedItem)
                {
                    gameBoard[newRow, newColumn] = 0;
                    CheckUp(gameBoard, newRow, newColumn, searchedItem);
                }
                else return;
            }
            catch (IndexOutOfRangeException)
            { return; }
        }

        private static void CheckDown(byte[,] gameBoard, int row, int column, int searchedItem)
        {
            int newRow = row - 1;
            int newColumn = column;
            try
            {
                if (gameBoard[newRow, newColumn] == searchedItem)
                {
                    gameBoard[newRow, newColumn] = 0;
                    CheckDown(gameBoard, newRow, newColumn, searchedItem);
                }
                else return;
            }
            catch (IndexOutOfRangeException)
            { return; }
        }
    }
}
