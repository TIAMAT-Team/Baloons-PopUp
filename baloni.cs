﻿using System;
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

        static bool doit(byte[,] matrix)
        {
            bool isWinner = true;
            Stack<byte> stek = new Stack<byte>();
            int columnLenght = matrix.GetLength(0);
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < columnLenght; i++)
                {
                    if (matrix[i, j] != 0)
                    {
                        isWinner = false;
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
            return isWinner;
        }

        static void sortAndPrintChartFive(string[,] tableToSort)
        {

            List<klasacia> klasirane = new List<klasacia>();

            for (int i = 0; i < 5; ++i)
            {
                if (tableToSort[i, 0] == null)
                {
                    break;
                }

                klasirane.Add(new klasacia(int.Parse(tableToSort[i, 0]), tableToSort[i, 1]));

            }

            klasirane.Sort();
            Console.WriteLine("---------TOP FIVE CHART-----------");
            for (int i = 0; i < klasirane.Count; ++i)
            {
                klasacia slot = klasirane[i];
                Console.WriteLine("{2}.   {0} with {1} moves.", slot.Name, slot.Value, i + 1);
            }
            Console.WriteLine("----------------------------------");


        }

        static void Main(string[] args)
        {
            string[,] topFive = new string[5, 2];
            byte[,] matrix = BalloonsField.GenerateRandomField(5, 10);

            DrawMatrix(matrix);

            string userInput = null;
            int userMoves = 0;

            while (userInput != "EXIT")
            {
                Console.WriteLine("Enter a row and column: ");
                userInput = Console.ReadLine();
                userInput = userInput.ToUpper().Trim();

                switch (userInput)
                {
                    case "RESTART":
                        matrix = BalloonsField.GenerateRandomField(5, 10);
                        DrawMatrix(matrix);

                        userMoves = 0;
                        break;

                    case "TOP":
                        sortAndPrintChartFive(topFive);
                        break;

                    default:
                        if ((userInput.Length == 3) && (userInput[0] >= '0' && userInput[0] <= '9') && (userInput[2] >= '0' && userInput[2] <= '9') && (userInput[1] == ' ' || userInput[1] == '.' || userInput[1] == ','))
                        {
                            int userRow, userColumn;
                            userRow = int.Parse(userInput[0].ToString());
                            if (userRow > 4)
                            {
                                Console.WriteLine("Wrong input ! Try Again ! ");
                                continue;
                            }
                            userColumn = int.Parse(userInput[2].ToString());

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
                            if (doit(matrix))
                            {
                                Console.WriteLine("Gratz ! You completed it in {0} moves.", userMoves);
                                if (topFive.signIfSkilled(userMoves))
                                {
                                    sortAndPrintChartFive(topFive);
                                }
                                else
                                {
                                    Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
                                }
                                matrix = BalloonsField.GenerateRandomField(5, 10);
                                userMoves = 0;
                            }
                            DrawMatrix(matrix);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong input ! Try Again ! ");
                            break;
                        }


                }
            }
            Console.WriteLine("Good Bye! ");

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


