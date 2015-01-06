namespace BalloonPopsGame
{
    using BalloonPopsGame.Commands;
    using BalloonPopsGame.Printers;
    using System;
    using System.Collections.Generic;

    public class Balloons
    {
        static void Main(string[] args)
        {
            string[,] topFive = new string[5, 2];
            var matrix = new BalloonsField(5, 10);
            IPrinter printer = new ConsolePrinter();
            ICommandParser commandParser = new CommandParser();
            ICommandInfo commandInfo;


            RankList rankList = new RankList();

            printer.PrintField(matrix);

            string userInput = null;

            while (true)
            {
                userInput = ReadUserInput();

                if (userInput == "EXIT")
                {
                    // TODO: run ExitCommand
                    break;
                }

                commandInfo = commandParser.Parse(userInput);
                // Console.WriteLine(commandInfo.CommandName);
                // Console.WriteLine(String.Join(", ", commandInfo.Arguments));

                switch (userInput)
                {
                    case "RESTART":
                       
                        break;

                    case "TOP":
                        // TODO: replace with printer.PringMessage(topFive); topfive should be a string from the ranklist class
                        printer.PrintRankList(rankList.GetRankList);
                        break;

                    case "EXIT":
                        printer.PringMessage("Good Bye! ");
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
                            printer.PringMessage("Wrong input ! Try Again ! ");
                            continue;
                        }

                        if (BalloonPopper.IsBalloonPopped(matrix, userRow, userColumn))
                        {
                            printer.PringMessage("cannot pop missing ballon!");
                            continue;
                        }
                        else
                        {
                            BalloonPopper.PopBalloons(matrix, userRow, userColumn);
                        }

                       // rankList.MovesCount++;
                        matrix.NormalizeBalloonField();

                        if (matrix.isWinner())
                        {
                      //      GameOver(rankList, ref matrix, rankList.MovesCount);
                        }

                        printer.PrintField(matrix);
                        break;
                }
            }
        }

        // TODO: remove method
        private static bool isValidInput(string userInput)
        {
            return (userInput.Length == 3) && (userInput[0] >= '0' && userInput[0] <= '9' && userInput[0] <= '4') &&
                (userInput[2] >= '0' && userInput[2] <= '9') &&
                (userInput[1] == ' ' || userInput[1] == '.' || userInput[1] == ',');
        }

        private static void GameOver(RankList rankList, ref BalloonsField matrix, ref int userMoves)
        {
            Console.WriteLine("Gratz ! You completed it in {0} moves.", userMoves);
            if (rankList.SignIfSkilled(rankList, userMoves))
            {
                //TODO: printer.PrintRankList(rankList.GetRankList);
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