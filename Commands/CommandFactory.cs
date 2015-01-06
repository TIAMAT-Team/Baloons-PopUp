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

        public CommandFactory(IPrinter printer, RankList rankList)
        {
            this.printer = printer;
            this.rankList = rankList;
        }

        public IBalloonPopsCommand CreateCommand(ICommandInfo commandInfo)
        {
            IBalloonPopsCommand balloonPopsCommand;
            var commandName = commandInfo.CommandName;
            var arguments = commandInfo.Arguments;

            if (commandName.StartsWith("RESTART"))
            {
                balloonPopsCommand = new RestartCommand(this.printer);
            }
            else if (commandName.StartsWith("TOP"))
            {
                balloonPopsCommand = new TopCommand(this.printer, this.rankList);
            }
            else
            {
                throw new ArgumentException("Invalid command.");
            }

            return balloonPopsCommand;
        }
    }
}
