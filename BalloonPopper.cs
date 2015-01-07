namespace BalloonPopsGame
{
    using System;

    public static class BalloonPopper
    {
        public static bool IsBalloonPopped(IBalloonsField matrix, int row, int col)
        {
            return matrix[row, col] == 0;
        }

        public static void PopBalloons(IBalloonsField matrix, int row, int col)
        {
            byte searchedTarget = matrix[row, col];
            matrix[row, col] = 0;
            CheckLeft(matrix, row, col, searchedTarget);
            CheckRight(matrix, row, col, searchedTarget);
            CheckUp(matrix, row, col, searchedTarget);
            CheckDown(matrix, row, col, searchedTarget);
        }

        private static void CheckLeft(IBalloonsField matrix, int row, int column, int searchedItem)
        {
            int newRow = row;
            int newColumn = column - 1;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    CheckLeft(matrix, newRow, newColumn, searchedItem);
                }
            }
            catch (IndexOutOfRangeException) { }
        }

        private static void CheckRight(IBalloonsField matrix, int row, int column, int searchedItem)
        {
            int newRow = row;
            int newColumn = column + 1;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    CheckRight(matrix, newRow, newColumn, searchedItem);
                }
            }
            catch (IndexOutOfRangeException) { }
        }

        private static void CheckUp(IBalloonsField matrix, int row, int column, int searchedItem)
        {
            int newRow = row + 1;
            int newColumn = column;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    CheckUp(matrix, newRow, newColumn, searchedItem);
                }
            }
            catch (IndexOutOfRangeException) { }
        }

        private static void CheckDown(IBalloonsField matrix, int row, int column, int searchedItem)
        {
            int newRow = row - 1;
            int newColumn = column;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    CheckDown(matrix, newRow, newColumn, searchedItem);
                }
            }
            catch (IndexOutOfRangeException) { }
        }
    }
}
