namespace BalloonPopsGame
{
    using BalloonPopsGame.Commands;
    using BalloonPopsGame.Printers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Balloons
    {
        static void Main(string[] args)
        {
            var matrix = new BalloonsField(5, 10);
            RankList rankList = new RankList();
            IPrinter printer = new ConsolePrinter();
            ICommandParser commandParser = new CommandParser();
            ICommandInfo commandInfo;
            ICommandFactory commandFactory = new CommandFactory(printer, rankList, matrix);

            printer.PrintField(matrix);

            string userInput;

            while (true)
            {
                printer.PrintMessage("Enter a row and column: ");
                userInput = ReadUserInput();

                if (userInput == "EXIT")
                {
                    printer.PrintMessage("Good Bye! ");
                    break;
                }

                try
                {
                    commandInfo = commandParser.Parse(userInput);
                    IBalloonPopsCommand command = commandFactory.CreateCommand(commandInfo);

                    command.Execute(commandInfo.Arguments.ToArray());
                }
                catch (ArgumentException)
                {
                    printer.PrintMessage("Wrong input ! Try Again ! ");
                    continue;
                }
                catch (IndexOutOfRangeException)
                {
                    printer.PrintMessage("Wrong input ! Try Again ! ");
                    continue;
                }
            }
        }

        private static string ReadUserInput()
        {
            string userInput = Console.ReadLine();
            userInput = userInput.ToUpper().Trim();
            return userInput;
        }


    }
}