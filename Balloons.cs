namespace BalloonPopsGame
{
    using System;
    using System.Collections.Generic;

    public class Balloons
    {
        static bool isWinner(byte[,] gameBoard)
        {
            for (int r = 0; r < gameBoard.GetLength(0); r++)
            {
                for (int c = 0; c < gameBoard.GetLength(1); c++)
                {
                    if (gameBoard[r, c] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static void NormalizeBalloonField(byte[,] gameBoard)
        {
            Stack<byte> stek = new Stack<byte>();
            int columnLenght = gameBoard.GetLength(0);

            for (int j = 0; j < gameBoard.GetLength(1); j++)
            {
                for (int i = 0; i < columnLenght; i++)
                {
                    if (gameBoard[i, j] != 0)
                    {
                        stek.Push(gameBoard[i, j]);
                    }
                }

                for (int k = columnLenght - 1; k >= 0; k--)
                {
                    try
                    {
                        gameBoard[k, j] = stek.Pop();
                    }
                    catch (Exception)
                    {
                        gameBoard[k, j] = 0;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            string[,] topFive = new string[5, 2];
            byte[,] gameBoard = BalloonsField.GenerateRandomField(5, 10);

            DrawGameBoard(gameBoard);

            string userInput = null;
            int userMoves = 0;

            do
            {
                userInput = ReadUserInput();
                
                switch (userInput)
                {
                    case "RESTART":
                        gameBoard = BalloonsField.GenerateRandomField(5, 10);
                        DrawGameBoard(gameBoard);
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
                            Console.WriteLine("Wrong input! Try Again! ");
                            continue;
                        }

                        if (BalloonPopper.IsBalloonPopped(gameBoard, userRow, userColumn))
                        {
                            Console.WriteLine("Cannot pop missing ballon!");
                            continue;
                        }
                        else
                        {
                            BalloonPopper.PopBalloons(gameBoard, userRow, userColumn);
                        }

                        userMoves++;
                        NormalizeBalloonField(gameBoard);
                        
                        if (isWinner(gameBoard))
                        {
                            GameOver(topFive, ref gameBoard, ref userMoves);
                        }

                        DrawGameBoard(gameBoard);
                        break;
                }
            }
            while (userInput != "EXIT");

        }

        private static bool isValidInput(string userInput)
        {
            return (userInput.Length == 3) && (userInput[0] >= '0' && userInput[0] <= '9' && userInput[0] <= '4') && (userInput[2] >= '0' && userInput[2] <= '9') && (userInput[1] == ' ' || userInput[1] == '.' || userInput[1] == ',');
        }

        private static void GameOver(string[,] topFive, ref byte[,] gameBoard, ref int userMoves)
        {
            Console.WriteLine("Congratulations! You completed it in {0} moves.", userMoves);
            if (RankList.SignIfSkilled(topFive, userMoves))
            {
                RankList.Print(topFive);
            }
            else
            {
                Console.WriteLine("I am sorry, your score is not high enough to be in top five chart!");
            }
            gameBoard = BalloonsField.GenerateRandomField(5, 10);
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

        private static void DrawGameBoard(byte[,] gameBoard)
        {
            Console.Write("    ");
            for (byte column = 0; column < gameBoard.GetLongLength(1); column++)
            {
                Console.Write(column + " ");
            }

            Console.Write("\n   ");
            for (byte column = 0; column < (gameBoard.GetLongLength(1) * 2) + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (byte i = 0; i < gameBoard.GetLongLength(0); i++)
            {
                Console.Write(i + " | ");
                for (byte j = 0; j < gameBoard.GetLongLength(1); j++)
                {
                    if (gameBoard[i, j] == 0)
                    {
                        Console.Write("  ");
                        continue;
                    }

                    Console.Write(gameBoard[i, j] + " ");
                }
                Console.Write("| ");
                Console.WriteLine();
            }

            Console.Write("   "); 
            for (byte column = 0; column < (gameBoard.GetLongLength(1) * 2) + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
        }
    }
}


