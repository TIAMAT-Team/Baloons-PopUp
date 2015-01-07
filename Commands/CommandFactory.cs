namespace BalloonPopsGame.Commands
{
    using BalloonPopsGame.Printers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandFactory : ICommandFactory
    {
        private IPrinter printer;
        private RankList rankList;
        private IBalloonsField gameBoard;

        public CommandFactory(IPrinter printer, RankList rankList, IBalloonsField gameBoard)
        {
            this.printer = printer;
            this.rankList = rankList;
            this.gameBoard = gameBoard;
        }

        public IBalloonPopsCommand CreateCommand(ICommandInfo commandInfo)
        {
            IBalloonPopsCommand balloonPopsCommand;
            var commandName = commandInfo.CommandName;
            var arguments = commandInfo.Arguments.ToArray();

            if (commandName.StartsWith("RESTART"))
            {
                balloonPopsCommand = new RestartCommand(this.printer);
            }
            else if (commandName.StartsWith("TOP"))
            {
                balloonPopsCommand = new TopCommand(this.printer, this.rankList);
            }
            else if (arguments.Count() == 2)
            {
                int row;
                int col;

                if (!int.TryParse(arguments[0], out row) || !int.TryParse(arguments[1], out col))
                {
                    throw new ArgumentException("Invalid parameters for the command.");
                }

                balloonPopsCommand = new BalloonsPopCommand(row, col, this.printer, this.rankList, this.gameBoard);
            }
            else
            {
                throw new ArgumentException("Invalid command.");
            }

            return balloonPopsCommand;
        }
    }
}
