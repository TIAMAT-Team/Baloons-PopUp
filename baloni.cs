using System;
using System.Collections.Generic;
using BalloonPopsGame;

namespace BalloonPopsGame
{
    class baloni
    {
        static void checkLeft(byte[,] matrix, int row, int column, int searchedItem)
        {
            int newRow = row;
            int newColumn = column - 1;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    checkLeft(matrix, newRow, newColumn, searchedItem);
                }
                else return;
            }
            catch (IndexOutOfRangeException)
            { return; }

        }
        static void checkRight(byte[,] matrix, int row, int column, int searchedItem)
        {
            int newRow = row;
            int newColumn = column + 1;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    checkRight(matrix, newRow, newColumn, searchedItem);
                }
                else return;
            }
            catch (IndexOutOfRangeException)
            { return; }

        }
        static void checkUp(byte[,] matrix, int row, int column, int searchedItem)
        {
            int newRow = row + 1;
            int newColumn = column;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    checkUp(matrix, newRow, newColumn, searchedItem);
                }
                else return;
            }
            catch (IndexOutOfRangeException)
            { return; }
        }
        static void checkDown(byte[,] matrix, int row, int column, int searchedItem)
        {
            int newRow = row - 1;
            int newColumn = column;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    checkDown(matrix, newRow, newColumn, searchedItem);
                }
                else return;
            }
            catch (IndexOutOfRangeException)
            { return; }

        }

        static bool isBalloonPopped(byte[,] matrix, int row, int col)
        {
            return matrix[row, col] == 0;
        }

        private static void popBalloons(byte[,] matrix, int row, int col)
        {
            byte searchedTarget = matrix[row, col];
            matrix[row, col] = 0;
            checkLeft(matrix, row, col, searchedTarget);
            checkRight(matrix, row, col, searchedTarget);
            checkUp(matrix, row, col, searchedTarget);
            checkDown(matrix, row, col, searchedTarget);
        }
        static bool isWinner(byte[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static void NormalizeBalloonField(byte[,] matrix)
        {

            Stack<byte> stek = new Stack<byte>();
            int columnLenght = matrix.GetLength(0);
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < columnLenght; i++)
                {
                    if (matrix[i, j] != 0)
                    {
                        stek.Push(matrix[i, j]);
                    }
                }
                for (int k = columnLenght - 1; (k >= 0); k--)
                {
                    try
                    {
                        matrix[k, j] = stek.Pop();
                    }
                    catch (Exception)
                    {
                        matrix[k, j] = 0;
                    }
                }
            }

        }

        static void Main(string[] args)
        {
            string[,] topFive = new string[5, 2];
            byte[,] matrix = BalloonsField.GenerateRandomField(5, 10);

            DrawMatrix(matrix);

            string userInput = null;
            int userMoves = 0;

            do
            {
                userInput = ReadUserInput();



                switch (userInput)
                {
                    case "RESTART":
                        matrix = BalloonsField.GenerateRandomField(5, 10);
                        DrawMatrix(matrix);

                        userMoves = 0;
                        break;

                    case "TOP":
                        RankList.Print(topFive);
                        break;

                    case "EXIT":
                        Console.WriteLine("Good Bye! ");
                        break;

                    default:

                        int userRow, userColumn;
                        if (isValidInput(userInput))
                        {

                            userRow = int.Parse(userInput[0].ToString());
                            userColumn = int.Parse(userInput[2].ToString());

                        }
                        else
                        {
                            Console.WriteLine("Wrong input ! Try Again ! ");
                            continue;
                        }


                        if (isBalloonPopped(matrix, userRow, userColumn))
                        {
                            Console.WriteLine("cannot pop missing ballon!");
                            continue;
                        }
                        else
                        {
                            popBalloons(matrix, userRow, userColumn);
                        }

                        userMoves++;
                        NormalizeBalloonField(matrix);
                        if (isWinner(matrix))
                        {
                            GameOver(topFive, ref matrix, ref userMoves);
                        }
                        DrawMatrix(matrix);
                        break;



                }
            }
            while (userInput != "EXIT");

        }

        private static bool isValidInput(string userInput)
        {
            return (userInput.Length == 3) && (userInput[0] >= '0' && userInput[0] <= '9' && userInput[0] <= '4') && (userInput[2] >= '0' && userInput[2] <= '9') && (userInput[1] == ' ' || userInput[1] == '.' || userInput[1] == ',');
        }

        private static void GameOver(string[,] topFive, ref byte[,] matrix, ref int userMoves)
        {
            Console.WriteLine("Gratz ! You completed it in {0} moves.", userMoves);
            if (RankList.SignIfSkilled(topFive, userMoves))
            {
                RankList.Print(topFive);
            }
            else
            {
                Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
            }
            matrix = BalloonsField.GenerateRandomField(5, 10);
            userMoves = 0;
        }

        private static string ReadUserInput()
        {
            Console.WriteLine("Enter a row and column: ");
            string userInput = null;
            userInput = Console.ReadLine();
            userInput = userInput.ToUpper().Trim();
            return userInput;
        }

        private static void DrawMatrix(byte[,] matrix)
        {
            Console.Write("    ");
            for (byte column = 0; column < matrix.GetLongLength(1); column++)
            {
                Console.Write(column + " ");
            }

            Console.Write("\n   ");
            for (byte column = 0; column < matrix.GetLongLength(1) * 2 + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (byte i = 0; i < matrix.GetLongLength(0); i++)
            {
                Console.Write(i + " | ");
                for (byte j = 0; j < matrix.GetLongLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        Console.Write("  ");
                        continue;
                    }

                    Console.Write(matrix[i, j] + " ");
                }
                Console.Write("| ");
                Console.WriteLine();
            }

            Console.Write("   ");     //some trinket stuff again
            for (byte column = 0; column < matrix.GetLongLength(1) * 2 + 1; column++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
    }
}


