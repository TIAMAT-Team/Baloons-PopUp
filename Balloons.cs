﻿namespace BalloonPopsGame
{
    using System;
    using System.Collections.Generic;

    public class Balloons
    {
        static void Main(string[] args)
        {
            string[,] topFive = new string[5, 2];
            var matrix = new BalloonsField(5, 10);

            matrix.Draw();

            string userInput = null;
            int userMoves = 0;

            do
            {
                userInput = ReadUserInput();

                switch (userInput)
                {
                    case "RESTART":
                        matrix = new BalloonsField(5, 10);
                        matrix.Draw();
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

                        if (BalloonPopper.IsBalloonPopped(matrix, userRow, userColumn))
                        {
                            Console.WriteLine("cannot pop missing ballon!");
                            continue;
                        }
                        else
                        {
                            BalloonPopper.PopBalloons(matrix, userRow, userColumn);
                        }

                        userMoves++;
                        matrix.NormalizeBalloonField();

                        if (matrix.isWinner())
                        {
                            GameOver(topFive, ref matrix, ref userMoves);
                        }

                        matrix.Draw();
                        break;
                }
            }
            while (userInput != "EXIT");

        }

        private static bool isValidInput(string userInput)
        {
            return (userInput.Length == 3) && (userInput[0] >= '0' && userInput[0] <= '9' && userInput[0] <= '4') && (userInput[2] >= '0' && userInput[2] <= '9') && (userInput[1] == ' ' || userInput[1] == '.' || userInput[1] == ',');
        }

        private static void GameOver(string[,] topFive, ref BalloonsField matrix, ref int userMoves)
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
            matrix = new BalloonsField(5, 10);
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


    }
}